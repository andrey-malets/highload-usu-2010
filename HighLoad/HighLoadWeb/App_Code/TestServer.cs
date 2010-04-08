using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Common;

/// <summary>
/// Summary description for TestServer
/// </summary>
public class TestServer
{
    private static List<DataContract> allData;

    static TestServer()
    {
        allData = new List<DataContract>();
        allData.Add(new DataContract(1, "abstract"));
        allData.Add(new DataContract(2, "event"));
        allData.Add(new DataContract(3, "new"));
        allData.Add(new DataContract(4, "struct"));
        allData.Add(new DataContract(5, "as"));
        allData.Add(new DataContract(6, "explicit"));
        allData.Add(new DataContract(7, "null"));
        allData.Add(new DataContract(8, "switch"));
        allData.Add(new DataContract(9, "base"));
        allData.Add(new DataContract(10, "extern"));
        allData.Add(new DataContract(11, "object"));
        allData.Add(new DataContract(12, "this"));
        allData.Add(new DataContract(13, "bool"));
        allData.Add(new DataContract(14, "false"));
        allData.Add(new DataContract(15, "operator"));
        allData.Add(new DataContract(16, "throw"));
        allData.Add(new DataContract(17, "break"));
        allData.Add(new DataContract(18, "finally"));
        allData.Add(new DataContract(19, "out"));
    }

    public static List<DataContract> GetAllData()
    {
        return allData;
    }

    private static DataContract getHighLoadDataString(Guid id)
    {
        return allData.Where<DataContract>(c => c.Id == id)
            .Take<DataContract>(1).ToList<DataContract>()[0];
    }

    public static void DeleteData(Guid id)
    {
        allData.Remove(getHighLoadDataString(id));
    }

    public static void AddData(DataContract data)
    {
        allData.Add(data);
    }

    public static void UpdateData(Guid id, int number, string name)
    {
        DataContract dataContract = getHighLoadDataString(id);
        dataContract.Number = number;
        dataContract.Name = name;
    }
}
