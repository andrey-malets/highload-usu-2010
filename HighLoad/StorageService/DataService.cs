using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Common;
using Common.DataContracts;

namespace StorageService
{
    public class DataService : IDisposable
    {
        private readonly HttpListener _httpListener;
        private readonly IDataSerializer _dataSerializer;

        public DataService( IServerEndpoint[] endpoints, IDataSerializer dataSerializer )
        {
            _dataSerializer = dataSerializer;

            //if ( urls == null || urls.Length == 0 )
            //    throw new ArgumentException( "urls" );

            _httpListener = new HttpListener();
            
            foreach ( var endpoint in endpoints )
                _httpListener.Prefixes.Add( String.Format( "{0}:{1}/", endpoint.Url, endpoint.Port ) );
        }

        public void Open()
        {
            _httpListener.Start();
            _httpListener.BeginGetContext( OnGetContext, null );
        }

        private void OnGetContext( IAsyncResult ar )
        {
            var httpContext = _httpListener.EndGetContext( ar );
            _httpListener.BeginGetContext( OnGetContext, null );

            ProcessRequest( httpContext );
        }

        private void ProcessRequest( HttpListenerContext context )
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

        public void Close()
        {
            _httpListener.Close();
        }

        public void Dispose()
        {
            if ( _httpListener.IsListening )
                Close();
        }
    }
}
