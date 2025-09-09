using UnityEngine;
using UnityEngine.UI;

public class DifficultyWindow : GenericWindow
{
    public int index = 0;

    public ToggleGroup toggleGroup;
    public Toggle[] toggles;
    public override void Open()
    {
        base.Open();
        // 저장 데이터가 없을 때만 기본값 Normal로
        if (SaveLoadManager.Data == null || string.IsNullOrEmpty(SaveLoadManager.Data.Difficulty))
        {
            toggles[SaveLoadManager.Data.index].isOn = true;
        }
        else
        {
            // 저장 데이터 있으면 그 난이도에 맞는 토글 켜기
            switch (SaveLoadManager.Data.Difficulty)
            {
                case "Easy": toggles[0].isOn = true; break;
                case "Normal": toggles[1].isOn = true; break;
                case "Hard": toggles[2].isOn = true; break;
            }
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SaveLoadManager.Data.index = index;
            SaveLoadManager.Save();
        }
    }

    public override void Close()
    {
        SaveLoadManager.Data.index = index;
        SaveLoadManager.Save();

        base.Close();
    }

    public void OnToggle()
    {
        for (int i = 0; i < toggles.Length; ++i)
        {
            if (toggles[i].isOn)
            {
                Debug.Log(i);
                break;
            }
        }
    }
    public void OnClickEasy(bool value)
    {   if(value)
        {
            // Debug.Log("OnClickEasy");

        }
    }
    public void OnClickNormal(bool value)
    {
        if (value)
        {
            //Debug.Log("OnClickNormal");
        }
    }
    public void OnClickHard(bool value)
    {
        if (value)
        {
           // Debug.Log("OnClickHard");
        }
    }
}
