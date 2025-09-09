using UnityEngine;

public class InventoryUiManager : MonoBehaviour
{
    [SerializeField] private GameObject invenSlotPrefab; // 슬롯 프리팹
    [SerializeField] private Transform contentParent;    // Content Transform

    public void CreateItemSlot()
    {
        // 프리팹 인스턴스 생성
        GameObject slot = Instantiate(invenSlotPrefab, contentParent);
        slot.name = "InvenSlot_" + contentParent.childCount;
    }
    public void RemoveItemSlot()
    {
        // Content에 자식이 하나라도 있으면 마지막 슬롯 제거
        if (contentParent.childCount > 0)
        {
            Transform lastSlot = contentParent.GetChild(contentParent.childCount - 1);
            Destroy(lastSlot.gameObject);
        }
    }
}
