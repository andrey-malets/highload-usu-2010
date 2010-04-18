using System.ServiceModel;
using NUnit.Framework;
using USU.HighLoad.Storage.StorageClient;

namespace ServiceTests
{
    [TestFixture]
    public class StorageServiceTest
    {
        [Test]
        public void AddMethodTest()
        {
            using ( var service = new StorageServiceClient( new BasicHttpBinding(), new EndpointAddress( @"http://localhost:801/StorageService/" ) ) )
            {
                service.Open();
                service.AddRecord( 1, "lalala" );
            }
        }
    }
}
