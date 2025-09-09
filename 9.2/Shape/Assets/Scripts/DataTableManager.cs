using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public static class DataTableManager
{
    private static readonly Dictionary<string, DataTable> tables =
        new Dictionary<string, DataTable>();

    static DataTableManager()
    {
        Init();
    }

    private static void Init()
    {
        // 문자열 테이블 등록
        var stringTable = new StringTable();
        stringTable.Load(DataTableIds.String);
        tables.Add(DataTableIds.String, stringTable);

        // 아이템 테이블 등록
        var itemTable = new ItemTable();
        itemTable.Load("Items"); // Assets/Resources/DataTables/Items.csv
        tables.Add("Items", itemTable);
    }

    public static StringTable stringTable
    {
        get { return Get<StringTable>(DataTableIds.String); }
    }

    public static ItemTable itemTable
    {
        get { return Get<ItemTable>("Items"); }
    }

    public static T Get<T>(string id) where T : DataTable
    {
        if (!tables.ContainsKey(id))
        {
            Debug.LogError("테이블 없음: " + id);
            return null;
        }
        return tables[id] as T;
    }

}
