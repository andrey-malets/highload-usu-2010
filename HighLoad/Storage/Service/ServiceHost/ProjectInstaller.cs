using System.ComponentModel;
using System.Configuration.Install;

namespace USU.HighLoad.Storage.ServicesHost
{
    [RunInstaller( true )]
    public partial class ProjectInstaller : Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}