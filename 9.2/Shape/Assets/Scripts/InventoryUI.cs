using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    private ItemTable.Data data;
    private int quantity;
    private InventoryUI parentUI;

    [SerializeField] private TextMeshProUGUI detailName;
    [SerializeField] private TextMeshProUGUI detailDescription;
    [SerializeField] private TextMeshProUGUI detailPrice;
    [SerializeField] private TextMeshProUGUI detailEffect;
    [SerializeField] private Image detailIcon;

    public void ShowItemDetail(ItemTable.Data data, int qty, InventoryUI parent)
    {
        this.data = data;
        this.quantity = qty;
        this.parentUI = parent;

        if (data == null) return;

        detailName.text = $"{data.Name} x{qty}";
        detailDescription.text = data.Description;
        detailPrice.text = $"{data.Price} G";
        detailEffect.text = data.Effect;
        var sprite = Resources.Load<Sprite>($"Icons/{data.Icon}");
        if (sprite != null)
            detailIcon.sprite = sprite;

        // 버튼 이벤트 등록 (여기에 넣어야 함)
        var btn = GetComponent<Button>();
        if (btn != null)
        {
            btn.onClick.RemoveAllListeners();
            btn.onClick.AddListener(OnClick);
        }
       
    }

    private void OnClick()
    {
        if (parentUI != null && data != null)
        {
            //parentUI.ShowItemDetail(data, quantity);
        }
    }
}


