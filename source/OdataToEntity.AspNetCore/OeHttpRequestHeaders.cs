using Microsoft.AspNetCore.Http;
using System;

namespace OdataToEntity.AspNetCore
{
    public sealed class OeHttpRequestHeaders : OeRequestHeaders
    {
        private readonly HttpResponse _response;

        public OeHttpRequestHeaders(OeRequestHeaders headers, HttpResponse response) 
            : base(headers)
        {
            _response = response;
            _response.ContentType = base.ContentType;
        }

        /// <summary>
        /// Создание копии текущего запроса
        /// </summary>
        /// <returns></returns>
        protected override OeRequestHeaders Clone() => new OeHttpRequestHeaders(this, _response);

        /// <summary>
        /// Тип контента возвращаемого ответа/результата
        /// </summary>
        public override String? ResponseContentType
        {
            get => _response.ContentType;
            set => _response.ContentType = value!;
        }
    }
}
