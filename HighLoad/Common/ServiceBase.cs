using System;
using System.Net;

namespace Common
{
    public abstract class ServiceBase : IDisposable
    {
        private readonly HttpListener _httpListener;
        
        protected ServiceBase( IServerEndpoint[] endpoints )
        {
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

        protected abstract void ProcessRequest( HttpListenerContext context );

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
