using UnityEngine;
using System.IO;

public class DifficultySaveManger
{
    public static SaveData Data;

    private static string Path => Application.persistentDataPath + "/save.json";

    public static void Save()
    {
        string json = JsonUtility.ToJson(Data, true);
        File.WriteAllText(Path, json);
        Debug.Log($"저장 완료: {Path}");
    }

    public static void Load()
    {
        if (!File.Exists(Path))
        {
            Debug.LogWarning("저장된 파일 없음");
            return;
        }

        string json = File.ReadAllText(Path);

        // 현재는 V3만 쓰지만, 버전 업그레이드 대응
        SaveData tempData = JsonUtility.FromJson<SaveDataV3>(json);

        // 최신 버전까지 업그레이드
        while (tempData.Version < 3)
        {
            tempData = tempData.VersionUp();
        }

        Data = tempData;
        Debug.Log($"불러오기 완료, 버전 {Data.Version}");
    }
}
