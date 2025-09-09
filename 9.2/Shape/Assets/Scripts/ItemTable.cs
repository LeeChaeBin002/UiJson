using System.Collections.Generic;
using UnityEngine;

public enum ItemTypes
{
    Weapon,
    Equip, //장착가능
    Consumable,
}

// ItemData 클래스 내 잘못된 static property 선언 및 오타 수정
public class ItemData
{
    public string Id { get; set; }
    public ItemTypes Type { get; set; }

    public string Name { get; set; }

    public string Desc { get; set; }

    public int Value { get; set; }

    public int Cost { get; set; }

    public string Icon { get; set; }

    public override string ToString()
    {
        return $"{Id}/{Type}/{Name}/{Desc}/{Value}/{Cost}/{Icon}";
    }

    public string StringName => DataTableManager.stringTable.Get(Name);
    public string StringDesc => DataTableManager.stringTable.Get(Desc);

    public Sprite SpriteIcon => Resources.Load<Sprite>($"Icon/{Icon}");
}
public class ItemTable : DataTable
{
   
        private readonly Dictionary<string, ItemData> table = new Dictionary<string, ItemData>();
        
    public override void Load(string filename)
    {
        table.Clear();
        // Resources/DataTables/Items.csv 파일 불러오기
        var path = string.Format(FormatPath, filename);
        var textAsset = Resources.Load<TextAsset>(path);
        var list = LoadCSV<ItemData>(textAsset.text);

        foreach (var item in list)
        {
            if(!table.ContainsKey(item.Id))
            {
                table.Add(item.Icon, item);
            }    
            else
            {
                Debug.LogError("아이템 아이디 중복!");
            }
        }
       foreach(var item in table)
        {
            var data = item.Value;
            Debug.Log(data.StringName);
            Debug.Log(data.StringDesc);
        }    

    }
    // Id로 아이템 가져오기
    public ItemData Get(string id)
    {
        if (!table.ContainsKey(id))
        {
            Debug.LogWarning($"아이템 없음: {id}");
            return null;
        }
        return table[id];
    }
}
