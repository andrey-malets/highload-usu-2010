using System;
using System.Collections.Generic;
using System.Text;
using Common;
using Common.Serialization;

namespace USU.HighLoad.Index.IndexServiceHost
{
    public class IndexServiceHost : ServiceBase
    {
        private IIndexServer indexServer;
        private IDataSerializer dataSerializer;
        private const int BuffSize = 8192;
        public IndexServiceHost(IIndexServer indexServer, IDataSerializer dataSerializer, ServerEndpoint[] endpoints)
            : base(endpoints)
        {
            this.indexServer = indexServer;
            this.dataSerializer = dataSerializer;
        }
        protected override void ProcessRequest(System.Net.HttpListenerContext context)
        {
            throw new NotImplementedException();
            /*
            byte[] buffer = new byte[BuffSize];
            context.Request.InputStream.Read(buffer, 0, BuffSize);
            */
        }
    }
}
