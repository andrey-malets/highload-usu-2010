using System;
using System.Collections.Generic;
using System.Linq;
using Common;

namespace App_Code
{
    public class TestServer
    {
        private static readonly List<DataContract> AllData;

        static TestServer()
        {
            AllData = new List<DataContract>
                          {
                              new DataContract(1, "abstract"),
                              new DataContract(2, "event"),
                              new DataContract(3, "new"),
                              new DataContract(4, "struct"),
                              new DataContract(5, "as"),
                              new DataContract(6, "explicit"),
                              new DataContract(7, "null"),
                              new DataContract(8, "switch"),
                              new DataContract(9, "base"),
                              new DataContract(10, "extern"),
                              new DataContract(11, "object"),
                              new DataContract(12, "this"),
                              new DataContract(13, "bool"),
                              new DataContract(14, "false"),
                              new DataContract(15, "operator"),
                              new DataContract(16, "throw"),
                              new DataContract(17, "break"),
                              new DataContract(18, "finally"),
                              new DataContract(19, "out")
                          };
        }

        public static List<DataContract> GetAllData()
        {
            return AllData;
        }

        private static DataContract GetHighLoadDataString(Guid id)
        {
            return AllData.Where(c => c.Id == id)
                .Take(1).ToList()[0];
        }

        public static void DeleteData(Guid id)
        {
            AllData.Remove(GetHighLoadDataString(id));
        }

        public static void AddData(DataContract data)
        {
            AllData.Add(data);
        }

        public static void UpdateData(Guid id, int number, string name)
        {
            DataContract dataContract = GetHighLoadDataString(id);
            dataContract.Number = number;
            dataContract.Name = name;
        }
    }
}