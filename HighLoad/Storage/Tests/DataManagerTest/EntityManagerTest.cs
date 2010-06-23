using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;
using NUnit.Framework;
using USU.HighLoad.Storage.DataManager;
using Common.DataContracts;
using USU.HighLoad.Storage.StorageDataContract;

namespace DataManagerTest
{
    [TestFixture]
    public class EntityManagerTest
    {
        [Test]
        public void SaveDataRecordTest()
        {
            var record = new DataRecord()
                            {
                                GlobalId = new Guid(),
                                Id = new Guid(),
                                RevisionDate = DateTime.Now,
                                Number = 1,
                                Name = "NewName",
                                IsDeleted = false,
                                Updated = Convert.ToInt64("1")
                            };

            EntityManager<DataRecord> manager = new EntityManager<DataRecord>();
            manager.Save(record);

            using (ISession session = DatabaseHelper.GetSession())
            {
                var recordFromDB = session.Get<DataRecord>(record.GlobalId);

                Assert.IsNotNull(recordFromDB);
                Assert.AreNotEqual(record, recordFromDB);
                Assert.AreEqual(record.GlobalId, recordFromDB.GlobalId);
                Assert.AreEqual(record.Id, recordFromDB.Id);
                Assert.AreEqual(record.RevisionDate, recordFromDB.RevisionDate);
                Assert.AreEqual(record.Number, recordFromDB.Number);
                Assert.AreEqual(record.Name, recordFromDB.Name);
                Assert.AreEqual(record.IsDeleted, recordFromDB.IsDeleted);
                Assert.AreEqual(record.Updated, recordFromDB.Updated);
            }
            
        }
    }
}
