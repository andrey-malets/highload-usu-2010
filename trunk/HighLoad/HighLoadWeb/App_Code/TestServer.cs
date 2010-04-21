using System;
using System.Collections.Generic;
using System.Linq;
using Common.DataContracts;

namespace App_Code
{
    public class TestServer
    {
        private static readonly List<DataRow> AllData;

        static TestServer()
        {
            AllData = new List<DataRow>
                          {
                              new DataRow(1, "abstract"),
                              new DataRow(2, "event"),
                              new DataRow(3, "new"),
                              new DataRow(4, "struct"),
                              new DataRow(5, "as"),
                              new DataRow(6, "explicit"),
                              new DataRow(7, "null"),
                              new DataRow(8, "switch"),
                              new DataRow(9, "base"),
                              new DataRow(10, "extern"),
                              new DataRow(11, "object"),
                              new DataRow(12, "this"),
                              new DataRow(13, "bool"),
                              new DataRow(14, "false"),
                              new DataRow(15, "operator"),
                              new DataRow(16, "throw"),
                              new DataRow(17, "break"),
                              new DataRow(18, "finally"),
                              new DataRow(19, "out")
                          };
        }

        public static List<DataRow> GetAllData()
        {
            return AllData;
        }

        public static DataRow GetData(Guid id)
        {
            return AllData.Where(c => c.Id == id).FirstOrDefault();
        }

        public static void DeleteData(Guid id)
        {
            AllData.Remove(GetData(id));
        }

        public static void AddData(DataRow data)
        {
            AllData.Add(data);
        }

        public static void UpdateData(Guid id, int number, string name)
        {
            DataRow dataRow = GetData(id);
            if (dataRow != null)
            {
                dataRow.Number = number;
                dataRow.Name = name;
            }
        }
    }
}