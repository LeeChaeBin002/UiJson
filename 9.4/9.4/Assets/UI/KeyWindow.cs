using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class KeyWindow : GenericWindow
{
    public bool canContinue = true;

    public Button cancleButton;
    public Button deleteButton;
    public Button acceptButton;

    private Button[] keyButtons;
    private string inputText = "";
    protected void Awake()
    {
        var buttons = gameObject.GetComponentInChildren<Button>();
        //var text = button.GetComponentInChildren<TextMeshPro>();
        //var key = text.text;
        //button.onClick.AddListener(
        //    () =>
        //    {
        //        OnKey(key);
        //    }
        //    );

        cancleButton.onClick.AddListener(OnClickcancleButton);//기존에 있는건 유지하고 추가로 클릭  
        deleteButton.onClick.AddListener(OnClickdeleteButton);
        acceptButton.onClick.AddListener(OnClickacceptButton);

        Transform buttonsParent = transform.Find("Buttons");
    }
    public void OnKey(string key)
    {
        Debug.Log("onkey");
    }
    public override void Open()
    {
        cancleButton.gameObject.SetActive(canContinue);
        firsetSelected = cancleButton.gameObject.activeSelf ? cancleButton.gameObject : deleteButton.gameObject;
        if (cancleButton.gameObject.activeSelf)
        {

        }

        base.Open();
    }

    public void OnClickcancleButton()
    {
        Debug.Log("OnClickCancle");
    }
    public void OnClickdeleteButton()
    {
        Debug.Log("OnClickDelete");
    }
    public void OnClickacceptButton()
    {
        Debug.Log("OnClickAccept");
    }
    private void OnClickKeyButton(int index)
    {
        Debug.Log("Key clicked: " + keyButtons[index].name);
        inputText += keyButtons[index].GetComponentInChildren<Text>().text;
    }
}
