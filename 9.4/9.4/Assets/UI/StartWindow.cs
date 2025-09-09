using UnityEngine;
using UnityEngine.UI;

public class StartWindow : GenericWindow
{
    public bool canContinue = true;

    public Button continueButton;
    public Button newGameButton;
    public Button optionButton;

    protected void Awake()
    {
        continueButton.onClick.AddListener(OnClickContinue);//기존에 있는건 유지하고 추가로 클릭  
        newGameButton.onClick.AddListener(OnClickNewGame);
        optionButton.onClick.AddListener(OnClickOption);
    }

    public override void Open()
    {
        continueButton.gameObject.SetActive(canContinue);
        firsetSelected = continueButton.gameObject.activeSelf ? continueButton.gameObject : newGameButton.gameObject;
        if(continueButton.gameObject.activeSelf)
        {

        }

        base.Open();
    }

    public void OnClickContinue()
    {
        Debug.Log("OnClickContinue");
    }
    public void OnClickNewGame()
    {
        Debug.Log("OnClickNewGame");
    }
    public void OnClickOption()
    {
        Debug.Log("OnClickOption");
    }
}
