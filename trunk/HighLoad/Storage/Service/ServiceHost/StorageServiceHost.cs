using System.ServiceProcess;
using System.ServiceModel;
using USU.HighLoad.Storage.StorageManager;

namespace USU.HighLoad.Storage.ServicesHost
{
    public partial class StorageServiceHost : ServiceBase
    {
        private ServiceHost _host;

        public StorageServiceHost()
        {
            InitializeComponent();
        }

        protected override void OnStart( string[] args )
        {
            _host = new ServiceHost( typeof( StorageService ) );
            _host.Open();
        }

        protected override void OnStop()
        {
            if ( _host != null )
                _host.Close();
        }
    }
}