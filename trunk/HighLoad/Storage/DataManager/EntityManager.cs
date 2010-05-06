using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using USU.HighLoad.Storage.StorageDataContract;
using Common.DataContracts;

namespace USU.HighLoad.Storage.DataManager
{
    public class EntityManager<T> : IDataManager<T> where T : class, IStoragable, new()
    {
        #region Члены IDataManager<T>

        public List<T> LoadAll()
        {
            return new List<T>();
        }

        public T Load(Guid id)
        {
            return new T();
        }

        public void Save(T record)
        {
        }

        public void Update(T record)
        {
        }

        #endregion
    }
}
