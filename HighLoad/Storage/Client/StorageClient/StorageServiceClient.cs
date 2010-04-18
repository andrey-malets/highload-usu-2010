using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using ClientBase;
using USU.HighLoad.Storage.ServiceContract;
using USU.HighLoad.Storage.StorageDataContract;

namespace USU.HighLoad.Storage.StorageClient
{
    public class StorageServiceClient : SelfClientBase<IStorageService>, IStorageService
    {
        public StorageServiceClient()
        {}
        public StorageServiceClient( Binding binding, EndpointAddress endpoint ) : base ( binding, endpoint )
        {  
        }

        public void AddRecord( int number, string name )
        {
            Channel.AddRecord( number, name );
        }

        public void DeleteRecord( Guid recordId )
        {
            Channel.DeleteRecord( recordId );
        }

        public DataRecord GetRecordById( Guid recordId )
        {
            return Channel.GetRecordById( recordId );
        }

        public List<DataRecord> GetAllRecords()
        {
            return Channel.GetAllRecords();
        }

        public void UpdateRecord( DataRecord record )
        {
            Channel.UpdateRecord( record );
        }
    }
}