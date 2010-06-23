using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using USU.HighLoad.Storage.StorageDataContract;
using Common.DataContracts;
using NHibernate.Criterion;

namespace USU.HighLoad.Storage.DataManager
{
    public class EntityManager<T> : IDataManager<T> where T : class, IStoragable, new()
    {
        #region Члены IDataManager<T>

        public List<T> LoadAll()
        {
            using (ISession session = DatabaseHelper.GetSession())
            {
                return session.CreateCriteria<DataRecord>().List<T>().ToList<T>();
            }
        }

        public T Load(Guid id)
        {
            using (ISession session = DatabaseHelper.GetSession())
            {
                return session
                        .CreateQuery("from Data p where p.GlobalId=:id")
                        .SetString("id", id.ToString())
                        .UniqueResult<T>();;
            }
        }


        public List<T> LoadList(Guid id)
        {
            using (ISession session = DatabaseHelper.GetSession())
            {
                return session
                        .CreateQuery("from Data p where p.Id=:id")
                        .SetString("id", id.ToString()).List<T>().ToList<T>();
            }
        }

        public void Save(T record)
        {
            using (ISession session = DatabaseHelper.GetSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(record);
                    transaction.Commit();
                }
            }
        }

        public void Update(T record)
        {
            using (ISession session = DatabaseHelper.GetSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(record);
                    transaction.Commit();
                }
            }
        }

        #endregion
    }
}
