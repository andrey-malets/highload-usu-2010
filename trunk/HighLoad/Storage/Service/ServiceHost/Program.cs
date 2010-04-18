using System.ServiceProcess;

namespace USU.HighLoad.Storage.ServicesHost
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun = new ServiceBase[] 
                                              { 
                                                  new StorageServiceHost() 
                                              };
            ServiceBase.Run( ServicesToRun );
        }
    }
}