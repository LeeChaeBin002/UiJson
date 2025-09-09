using System.Collections.Generic;
using UnityEngine;

public class WindowManager : MonoBehaviour
{
    public List<GenericWindow> windows;

    public Windows defaultWindow;
    //인스턴스에 의해 직렬화가 안됌,런타임에만 사용가능,현재 윈도우 갱신
    public Windows CurrnetWindow { get; private set; }

    public void Start()
    {
        foreach(var window in windows)
        {
            window.Init(this);
            //window.Close();
            window.gameObject.SetActive(false);
        }

        CurrnetWindow = defaultWindow;
        windows[(int)CurrnetWindow].Open();
    }
    public void Open(Windows id)
    {
        windows[(int)CurrnetWindow].Close();
        CurrnetWindow = id;
        windows[(int)CurrnetWindow].Open();
    }
}
