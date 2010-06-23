using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;
using USU.HighLoad.Storage.ServiceContract;
using USU.HighLoad.Storage.StorageDataContract;
using USU.HighLoad.Storage.DataManager;

namespace USU.HighLoad.Storage.StorageManager
{
    [ServiceBehavior ( InstanceContextMode = InstanceContextMode.PerCall )]
    public sealed class StorageService : IStorageService
    {
        IDataManager<DataRecord> manager = new EntityManager<DataRecord>();

        public void AddRecord( int number, string name )
        {

            List<DataRecord> records = manager.LoadAll().FindAll(r => r.Name == name && r.Number == number);
            if (records != null && records.Count != 0)
                throw new Exception();
            
            manager.Save(
                new DataRecord()
                    {
                        GlobalId = Guid.NewGuid(),//000000-000...?
                        Id = Guid.NewGuid(),
                        IsDeleted = false,
                        RevisionDate = DateTime.Now,
                        Updated = 0,
                        Name = name,
                        Number = number
                    }
                );
        }

        public void DeleteRecord( Guid recordId )
        {
            List<DataRecord> records = manager.LoadList(recordId);
            records.Sort((x, y) => x.Updated.CompareTo(y.Updated));
            var oldRecord = records[records.Count - 1];
            manager.Update(
                new DataRecord()
                {
                    GlobalId = recordId,
                    Id = Guid.NewGuid(),
                    IsDeleted = true,
                    RevisionDate = DateTime.Now,
                    Updated = oldRecord.Updated + 1,
                    Name = oldRecord.Name,
                    Number = oldRecord.Number
                }
                ); ;
        }

        public DataRecord GetRecordById( Guid recordId )
        {
            return manager.Load(recordId);
        }

        public List<DataRecord> GetAllRecords()
        {
            return manager.LoadAll();
        }

        public void UpdateRecord( DataRecord record )
        {
            manager.Update(record);
        }
    }
}