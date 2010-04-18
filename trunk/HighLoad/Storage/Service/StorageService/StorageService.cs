using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using USU.HighLoad.Storage.ServiceContract;
using USU.HighLoad.Storage.StorageDataContract;

namespace USU.HighLoad.Storage.StorageManager
{
    [ServiceBehavior ( InstanceContextMode = InstanceContextMode.PerCall )]
    public sealed class StorageService : IStorageService
    {
        public void AddRecord( int number, string name )
        {
            Thread.Sleep( 3000 );
        }

        public void DeleteRecord( Guid recordId )
        {
            throw new System.NotImplementedException();
        }

        public DataRecord GetRecordById( Guid recordId )
        {
            throw new System.NotImplementedException();
        }

        public List<DataRecord> GetAllRecords()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateRecord( DataRecord record )
        {
            throw new System.NotImplementedException();
        }
    }
}