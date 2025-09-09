using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventorySlotUI : MonoBehaviour
{

    private ItemTable.ItemData data;
    private int quantity;
    private InventoryUI parentUI;

    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI descriptionText;
    [SerializeField] private TextMeshProUGUI priceText;
    [SerializeField] private TextMeshProUGUI effectText;

    public void SetData(ItemTable.Data data, int qty, InventoryUI parent)
    {
        this.data = data;
        this.quantity = qty;
        this.parentUI = parent;

        if (data == null) return;

        if (nameText != null) nameText.text = $"{data.Name} x{quantity}";
        if (descriptionText != null) descriptionText.text = data.Description;
        if (priceText != null) priceText.text = $"{data.Price} G";
        if (effectText != null) effectText.text = data.Effect;

        GetComponent<Button>().onClick.AddListener(OnClick);

}

    private void OnClick()
    {
        //parentUI.ShowItemDetail(data, quantity);
    }
}
