﻿using ODataClient.Default;
using OdataToEntity.Test;
using System;
using System.ServiceModel;

namespace OdataToEntity.WcfClient
{
    class Program
    {
        private static readonly WcfClientInterceptor _interceptor = new WcfClientInterceptor(new NetTcpBinding(), RemoteAddress);
        public const String RemoteAddress = "net.tcp://localhost:5000/OdataWcfService";

        private static Container ContainerFactory()
        {
            var container = new Container(new Uri("http://dummy"));
            _interceptor.AttachToContext(container);
            return container;
        }

        static void Main(string[] args)
        {
            DbFixture.ContainerFactory = ContainerFactory;

            DbFixture.RunTest(new OdataToEntityCore.AspClient.BatchTest()).GetAwaiter().GetResult();
            DbFixture.RunTest(new SelectTest()).GetAwaiter().GetResult();

            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
