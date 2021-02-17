using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mime;
using System.Text;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ASE.MD.MDP2.Product.MDP2Service.Utils
{
    public static class SerializationManager
    {
        private static readonly JsonSerializerSettings JsonSettings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };

        public static string XmlSerialize(object data)
        {
            if (data == null) return null;
            var serializer = new XmlSerializer(data.GetType());
            try
            {
                using (var sw = new StringWriter())
                using (var xw = new XmlTextWriter(sw))
                {
                    serializer.Serialize(xw, data);
                    return sw.ToString();
                }
            }
            catch
            {
                return null;
            }
        }

        public static T XmlDeserialize<T>(string xmlData, T defaultValue = default(T))
        {
            if (string.IsNullOrWhiteSpace(xmlData)) return defaultValue;
            var serializer = new XmlSerializer(typeof(T));
            try
            {
                using (var sr = new StringReader(xmlData))
                using (var xr = new XmlTextReader(sr))
                    return (T)serializer.Deserialize(xr);
            }
            catch
            {
                return defaultValue;
            }
        }
        
        public static string JsonSerialize(object obj)
        {
            //TODO: comment 22.12.2020
            //return Application.Current.Dispatcher.Invoke(() => JsonConvert.SerializeObject(obj, JsonSettings));
            ////It's not built-in, but my AsyncContext and AsyncContextThread types are available in a library that would fit your need.
            ////    AsyncContext takes over the current thread: //https://stackoverflow.com/questions/41748335/net-dispatcher-for-net-core
            //AsyncContext.Run(async () =>
            //{
            //    ... // any awaits in here resume on the same thread.
            //});

            return JsonConvert.SerializeObject(obj, JsonSettings);
        }

        public static T JsonDeserialize<T>(string jsonData, T defaultValue = default(T))
        {
            if (string.IsNullOrWhiteSpace(jsonData))
                return defaultValue;

            try
            {
                return JsonConvert.DeserializeObject<T>(jsonData, JsonSettings);
            }
            catch
            {
                return defaultValue;
            }
        }

        public static object JsonDeserialize(string jsonData)
        {
            if (string.IsNullOrWhiteSpace(jsonData))
                return null;

            try
            {
                return JsonConvert.DeserializeObject(jsonData, JsonSettings);
            }
            catch
            {
                return null;
            }
        }
    }
}
