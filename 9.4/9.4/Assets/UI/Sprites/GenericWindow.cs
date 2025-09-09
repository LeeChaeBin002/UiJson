using UnityEngine;
using UnityEngine.EventSystems;

public class GenericWindow : MonoBehaviour
{
    public GameObject firsetSelected;

    protected WindowManager manager;
    public void Init(WindowManager mgr)
    {
        manager = mgr;
    }
    public void OnFocus()
    {   //이벤트 시스템 레퍼런스를 가져옴 인터렉티브
        EventSystem.current.SetSelectedGameObject(firsetSelected);
    }
    public virtual void Open()
    {
        gameObject.SetActive(true);
        OnFocus();
    }

    public virtual void Close()
    {
        gameObject.SetActive(false);
    }
}
