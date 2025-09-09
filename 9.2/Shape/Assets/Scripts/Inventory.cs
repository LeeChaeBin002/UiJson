using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<InventoryItem> items = new List<InventoryItem>();

    [SerializeField] private TextMeshProUGUI uiText; // UI Text 연결

    // 아이템 추가
    public void AddItem(string itemId, int count = 1)
    {
        var existing = items.Find(x => x.itemId == itemId);
        if (existing != null)
        {
            existing.quantity += count;
        }
        else
        {
            items.Add(new InventoryItem(itemId, count));
        }

        RefreshUI();
    }

    // 아이템 제거
    public void RemoveItem(string itemId, int count = 1)
    {
        var existing = items.Find(x => x.itemId == itemId);
        if (existing == null) return;

        existing.quantity -= count;
        if (existing.quantity <= 0)
            items.Remove(existing);

        RefreshUI();
    }

    // UI 갱신
    private void RefreshUI()
    {
        if (uiText == null) return;

        uiText.text = "===== 인벤토리 =====\n";

        foreach (var slot in items)
        {
            var data = slot.GetData();
            if (data != null)
            {
                uiText.text += $"{data.Name} x{slot.quantity}\n";
            }
        }
    }
    public List<InventoryItem> GetItems()
    {
        return items;
    }
}
