using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Common;
using Common.Serialization;
using StorageService;

namespace ServiceHost
{
    class Program
    {
        class TestDataSerializer : IDataSerializer
        {
            private readonly BinaryFormatter _binaryFormatter;

            public TestDataSerializer()
            {
                _binaryFormatter = new BinaryFormatter();
            }

            public byte[] Serialize<T>( T param )
            {
                var mem = new MemoryStream();
                _binaryFormatter.Serialize( mem, param );
                return mem.ToArray();
            }

            public T Deserialize<T>( byte[] bytes )
            {
                return (T)_binaryFormatter.Deserialize( new MemoryStream( bytes ) );
            }
        }

        static void Main( string[] args )
        {
            var endpoints = new[] {new ServerEndpoint {Port = "8001", Url = "http://localhost"}};

            using ( var service = new DataService( endpoints, new TestDataSerializer() ) )
            {
                try
                {
                    service.Open();
                    Console.WriteLine( "service run");
                }
                catch ( Exception ex )
                {
                    Console.Write( ex.Message );
                }
                Console.ReadLine();
            }
        }
    }
}
