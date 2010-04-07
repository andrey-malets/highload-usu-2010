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
    private static List<HighLoadDataString> allData;

    static TestServer()
    {
        allData = new List<HighLoadDataString>();
        allData.Add(new HighLoadDataString(1, "abstract"));
        allData.Add(new HighLoadDataString(2, "event"));
        allData.Add(new HighLoadDataString(3, "new"));
        allData.Add(new HighLoadDataString(4, "struct"));
        allData.Add(new HighLoadDataString(5, "as"));
        allData.Add(new HighLoadDataString(6, "explicit"));
        allData.Add(new HighLoadDataString(7, "null"));
        allData.Add(new HighLoadDataString(8, "switch"));
        allData.Add(new HighLoadDataString(9, "base"));
        allData.Add(new HighLoadDataString(10, "extern"));
        allData.Add(new HighLoadDataString(11, "object"));
        allData.Add(new HighLoadDataString(12, "this"));
        allData.Add(new HighLoadDataString(13, "bool"));
        allData.Add(new HighLoadDataString(14, "false"));
        allData.Add(new HighLoadDataString(15, "operator"));
        allData.Add(new HighLoadDataString(16, "throw"));
        allData.Add(new HighLoadDataString(17, "break"));
        allData.Add(new HighLoadDataString(18, "finally"));
        allData.Add(new HighLoadDataString(19, "out"));
    }

    public static List<HighLoadDataString> GetAllData()
    {
        return allData;
    }

    private static HighLoadDataString getHighLoadDataString(Guid id)
    {
        return allData.Where<HighLoadDataString>(c => c.Id == id)
            .Take<HighLoadDataString>(1).ToList<HighLoadDataString>()[0];
    }

    public static void DeleteData(Guid id)
    {
        allData.Remove(getHighLoadDataString(id));
    }

    public static void AddData(HighLoadDataString data)
    {
        allData.Add(data);
    }

    public static void UpdateData(Guid id, int number, string name)
    {
        HighLoadDataString highLoadDataString = getHighLoadDataString(id);
        highLoadDataString.Number = number;
        highLoadDataString.Name = name;
    }
}
