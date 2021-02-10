﻿using Microsoft.OData;
using System;
using System.IO;

namespace OdataToEntity
{
    /// <summary>
    /// Уровень описания метаданных сущности
    /// </summary>
    public enum OeMetadataLevel
    {
        None,
        Minimal,
        Full
    };

    /// <summary>
    /// Описание заголовка запроса
    /// 
    /// Постраничная выборка данных
    /// Server-Driven Paging (http://docs.oasis-open.org/odata/odata/v4.0/os/part1-protocol/odata-v4.0-os-part1-protocol.html#_Toc372793701) позволяет
    /// получить частичный набор данных размер которого устанавливается через метод OeRequestHeaders.SetMaxPageSize(int maxPageSize).
    ///
    /// Сервер возвращает данные и ссылку на следующею часть в аннотации @odata.nextLink, где меткой $skiptoken записано начало следующей части данных.
    /// Если запрос возвращает данные где в сортировке участвует столбец допускающий значения NULL в базе данных (не указан атрибут Required),
    /// необходимо установить свойство OeDataAdapter.IsDatabaseNullHighestValue для SQLite, MySql, Sql Server в false, для PostgreSql, Oracle в true.
    ///
    /// Если необходимо получить ссылки, а не реальные данные навигационных свойств один ко многим, необходимо вызывать метод OeRequestHeaders.SetNavigationNextLink(true): OeRequestHeaders.JsonDefault.SetMaxPageSize(10).SetNavigationNextLink(true);
    /// </summary>
    public class OeRequestHeaders
    {
        private static readonly Stream _emptyStream = new MemoryStream();
        public static readonly OeRequestHeaders JsonDefault = new OeRequestHeaders("application/json", OeMetadataLevel.Minimal, true, "utf-8");
        public static readonly OeRequestHeaders TextDefault = new OeRequestHeaders("text/plain", OeMetadataLevel.Minimal, true, "utf-8");

        protected OeRequestHeaders(OeRequestHeaders clone) 
            : this(clone.MimeType, clone.MetadataLevel, clone.Streaming, clone.Charset)
        {
            MaxPageSize = clone.MaxPageSize;
        }
        
        protected OeRequestHeaders(String mimeType, OeMetadataLevel metadataLevel, bool streaming, String charset)
        {
            MimeType = mimeType;
            MetadataLevel = metadataLevel;
            Streaming = streaming;
            Charset = charset;

            ContentType = GetContentType(mimeType, metadataLevel, streaming, charset);
        }

        /// <summary>
        /// Определить тип контента
        /// </summary>
        /// <param name="mimeType"></param>
        /// <param name="metadataLevel"></param>
        /// <param name="streaming"></param>
        /// <param name="charset"></param>
        /// <returns></returns>
        private static String GetContentType(String mimeType, OeMetadataLevel metadataLevel, bool streaming, String charset)
        {
            var metadataArg = metadataLevel switch
            {
                OeMetadataLevel.None => "none",
                OeMetadataLevel.Full => "full",
                _ => "minimal",
            };
            
            String streamingArg = streaming ? "true" : "false";
            
            return $"{mimeType};odata.metadata={metadataArg};odata.streaming={streamingArg};charset={charset}";
        }
        
        private static int GetParameterValue(String acceptHeader, String parameterName, out int valueLength)
        {
            valueLength = 0;

            if (acceptHeader == null)
                return -1;

            int i = acceptHeader.IndexOf(parameterName, StringComparison.OrdinalIgnoreCase);
            if (i == -1)
                return -1;

            if (i > 0)
                if (!Char.IsWhiteSpace(acceptHeader, i - 1) && acceptHeader[i - 1] != ';')
                    return -1;

            i += parameterName.Length;
            while (i < acceptHeader.Length && Char.IsWhiteSpace(acceptHeader, i))
                i++;

            if (acceptHeader[i] != '=')
                return -1;

            do
            {
                i++;
            }
            while (i < acceptHeader.Length && Char.IsWhiteSpace(acceptHeader, i));
            int start = i;

            do
            {
                i++;
                valueLength++;
            }
            while (i < acceptHeader.Length && !(Char.IsWhiteSpace(acceptHeader, i) || acceptHeader[i] == ';'));

            return start;
        }
        
        public static OeRequestHeaders Parse(String acceptHeader)
        {
            var metadataLevel = OeMetadataLevel.Minimal;
            bool streaming = true;

            int start;
            start = GetParameterValue(acceptHeader, "odata.metadata", out _);
            if (start != -1)
            {
                if (String.Compare(acceptHeader, start, "none", 0, "none".Length, StringComparison.OrdinalIgnoreCase) == 0)
                    metadataLevel = OeMetadataLevel.None;
                else if (String.Compare(acceptHeader, start, "full", 0, "full".Length, StringComparison.OrdinalIgnoreCase) == 0)
                    metadataLevel = OeMetadataLevel.Full;
            }

            start = GetParameterValue(acceptHeader, "charset", out int valueLength);
            if (start != -1)
                if (String.Compare(acceptHeader, start, "utf-8", 0, "utf-8".Length, StringComparison.OrdinalIgnoreCase) != 0)
                    throw new NotSupportedException("charset=" + acceptHeader.Substring(start, valueLength) + " not supported");

            start = GetParameterValue(acceptHeader, "odata.streaming", out _);
            if (start != -1)
                streaming = String.Compare(acceptHeader, start, "true", 0, "true".Length, StringComparison.OrdinalIgnoreCase) == 0;

            if (metadataLevel == JsonDefault.MetadataLevel && streaming == JsonDefault.Streaming)
                return JsonDefault;
            else
                return new OeRequestHeaders("application/json", metadataLevel, streaming, "utf-8");
        }
        
        public static OeRequestHeaders Parse(String acceptHeader, String preferHeader)
        {
            OeRequestHeaders requestHeaders = Parse(acceptHeader);
            if (String.IsNullOrEmpty(preferHeader))
                return requestHeaders;

            var message = new Infrastructure.OeInMemoryMessage(_emptyStream, null);
            message.SetHeader("Prefer", preferHeader);
            ODataPreferenceHeader preferenceHeader = message.PreferHeader();
            if (preferenceHeader.MaxPageSize == null)
                return requestHeaders;

            return requestHeaders.SetMaxPageSize(preferenceHeader.MaxPageSize.GetValueOrDefault());
        }
        
        protected virtual OeRequestHeaders Clone() => new OeRequestHeaders(this);
        
        /// <summary>
        /// Максимальный размер выборки данных на странице
        /// </summary>
        /// <param name="maxPageSize"></param>
        /// <returns></returns>
        public OeRequestHeaders SetMaxPageSize(int maxPageSize)
        {
            if (MaxPageSize == maxPageSize)
                return this;

            OeRequestHeaders requestHeaders = Clone();
            requestHeaders.MaxPageSize = maxPageSize;
            
            return requestHeaders;
        }

        /// <summary>
        /// Кодировка
        /// </summary>
        public String Charset { get; }
        
        /// <summary>
        /// Тип контента для OData
        /// </summary>
        public String ContentType { get; }

        /// <summary>
        /// Уровень описания метаданных сущности
        /// </summary>
        public OeMetadataLevel MetadataLevel { get; }

        /// <summary>
        /// Тип иммитации/контента (application/json и т.д.) (?)
        /// </summary>
        public String MimeType { get; }
        
        /// <summary>
        /// Максимальный размер страницы выборки данных
        /// </summary>
        public int MaxPageSize { get; private set; }
        
        /// <summary>
        /// Тип контента возвращаемого ответа/результата
        /// </summary>
        public virtual String? ResponseContentType { get; set; }

        /// <summary>
        /// Потоковая передача
        /// </summary>
        public bool Streaming { get; }
    }
}
