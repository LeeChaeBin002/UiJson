using UnityEngine;

public class GameManager : MonoBehaviour
{
    void Start()
    {
        var potion = DataTableManager.itemTable.Get("POTION");
        if (potion != null)
        {
            Debug.Log($"{potion.Name} ({potion.Type})");
            Debug.Log($"설명: {potion.Description}");
            Debug.Log($"가격: {potion.Price} G");
            Debug.Log($"효과: {potion.Effect}");
        }
    }
}
