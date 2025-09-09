using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.Interactions;
using UnityEngine.UI;

public class UiInvenSlotList : MonoBehaviour
{
    public UiInvenSlot prefab;

    public ScrollRect scrollRect;

    private List<UiInvenSlot> slotList = new List<UiInvenSlot>();

    public int maxCount = 30;
    private int itemCount = 0;

    private List<ItemData> testItemList = new List<ItemData>();

    private void Awake()
    {
        for (int i = 0; i < maxCount; ++i)
        {
            var newSlot = Instantiate(prefab, scrollRect.content);
            newSlot.slotIndex = i;
            newSlot.SetEmpty();
            newSlot.gameObject.SetActive(false);
            slotList.Add(newSlot);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AddRandomItem();
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            RemoveItem(0);
        }
    }

    private void UpdateSlots(List<saveItemData> itemList)
    {
        if (slotList.Count < itemList.Count)
        {
            for (int i = slotList.Count; i < itemList.Count; ++i)
            {
                var newSlot = Instantiate(prefab, scrollRect.content);
                newSlot.slotIndex = i;
                newSlot.SetEmpty();
                newSlot.gameObject.SetActive(false);
                slotList.Add(newSlot);
            }
        }

        for (int i = 0; i < slotList.Count; ++i)
        {
            if (i < itemList.Count)
            {
                slotList[i].gameObject.SetActive(true);
                slotList[i].SetItem(itemList[i]);
            }
            else
            {
                slotList[i].SetEmpty();
                slotList[i].gameObject.SetActive(false);
            }
        }
    }

    public void AddRandomItem()
    {
        //var itemData = DataTableManger.ItemTable.GetRandom();

        var itemInstance = new SaveItemData();
        itemInstance.itemData = DataTableManger.ItemTable.GetRandom();
        testItemList.Add(itemData);
        UpdateSlots(testItemList);
    }

    public void RemoveItem(int slotIndex)
    {
        testItemList.RemoveAt(slotIndex);
        UpdateSlots(testItemList);
    }

}
