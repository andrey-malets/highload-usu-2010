using System.Collections.Generic;
using System.Net;
using Common;
using Common.DataContracts;
using Common.Serialization;

namespace StorageService
{
    public class DataService : ServiceBase
    {
        private readonly IDataSerializer _dataSerializer;

        public DataService( IServerEndpoint[] endpoints, IDataSerializer dataSerializer ) : base (endpoints)
        {
            _dataSerializer = dataSerializer;
        }

        protected override void ProcessRequest( HttpListenerContext context )
        {
            var request = context.Request;
            switch ( request.QueryString["operation"] )
            {
                case ServiceOperations.GetAll:
                    var records = GetAllRecords();
                    var bytes = _dataSerializer.Serialize( records );
                    var output = context.Response.OutputStream;
                    output.Write( bytes, 0, bytes.Length );
                    output.Close();
                    break;
            }
        }

        private List<DataRow> GetAllRecords()
        {
            return new List<DataRow>
                       {
                           new DataRow( 1, "lalala" ),
                           new DataRow( 2, "bububu" )
                       };
        }
    }
}
