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
    public TextMeshProUGUI inputDisplay; // 언더바가 있는 UI 텍스트

    private Button[] keyButtons;
    private string inputText = "";
    protected void Awake()
    {
        keyButtons =GetComponentsInChildren<Button>();
        //var text = button.GetComponentInChildren<TextMeshPro>();
        //var key = text.text;
        //button.onClick.AddListener(
        //    () =>
        //    {
        //        OnKey(key);
        //    }
        //    );
        foreach (var button in keyButtons)
        {
            var text = button.GetComponentInChildren<TextMeshProUGUI>();
            if (text == null) continue;

            string key = text.text; // 버튼에 표시된 글자
            button.onClick.AddListener(() => OnKey(key));
        }
        cancleButton.onClick.AddListener(OnClickcancleButton);//기존에 있는건 유지하고 추가로 클릭  
        deleteButton.onClick.AddListener(OnClickdeleteButton);
        acceptButton.onClick.AddListener(OnClickacceptButton);

        Transform buttonsParent = transform.Find("Buttons");
    }
    public void OnKey(string key)
    {
        Debug.Log("onkey");
    }
    private void UpdateDisplay()
    {
        if (inputDisplay != null)
        {
            inputDisplay.text = inputText + "_"; // 언더바 뒤는 항상 유지
        }
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

        inputText = "";
        UpdateDisplay();
        Debug.Log("OnClickCancle");
    }
    public void OnClickdeleteButton()
    {
        if (inputText.Length > 0)
        {
            inputText = inputText.Substring(0, inputText.Length - 1);
            UpdateDisplay();
        }
        Debug.Log("OnClickDelete");
    }
    public void OnClickacceptButton()
    {
        Debug.Log("네임 완료");
    }
    private void OnClickKeyButton(int index)
    {
        Debug.Log("Key clicked: " + keyButtons[index].name);
        inputText += keyButtons[index].GetComponentInChildren<Text>().text;
    }
}
