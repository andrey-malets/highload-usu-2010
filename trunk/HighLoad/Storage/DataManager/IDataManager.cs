using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.DataContracts;

namespace USU.HighLoad.Storage.DataManager
{
    public interface IDataManager<T> where T : IStoragable
    {
        List<T> LoadAll();

        T Load(Guid id);

        void Save(T record);

        void Update(T record);
    }
}
