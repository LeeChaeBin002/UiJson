using UnityEngine;

public class InventoryItem
{
    public string itemId;   // CSV Id
    public int quantity;    // 개수

    public InventoryItem(string id, int qty = 1)
    {
        itemId = id;
        quantity = qty;
    }

    public ItemTable.Data GetData()
    {
        // 아이템 정보는 ItemTable에서 가져옴
        return DataTableManager.itemTable.Get(itemId);
    }
}
