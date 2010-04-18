using System;
using System.Collections.Generic;
using System.ServiceModel;
using USU.HighLoad.Storage.StorageDataContract;

namespace USU.HighLoad.Storage.ServiceContract
{
    [ServiceContract]
    public interface IStorageService
    {
        [OperationContract]
        void AddRecord( int number, string name );

        [OperationContract]
        void DeleteRecord( Guid recordId );

        [OperationContract]
        DataRecord GetRecordById( Guid recordId );

        [OperationContract]
        List<DataRecord> GetAllRecords();

        [OperationContract]
        void UpdateRecord( DataRecord record );
    }
}