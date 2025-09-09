using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiInvenSlot : MonoBehaviour
{
    public int slotIndex { get; set; }

    public Image imageIcon;
    public TextMeshProUGUI textName;

    public ItemData ItemData { get; private set; }

    public void SetEmpty()
    {
        ItemData = null;
        imageIcon.sprite = null;
        textName.text = string.Empty;
    }

    public void SetItem(ItemData data)
    {
        ItemData = data;
        imageIcon.sprite = ItemData.itemId.SpriteIcon;
        textName.text = ItemData.StringName;
    }
}
