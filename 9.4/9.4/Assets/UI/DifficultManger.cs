using UnityEngine;
using UnityEngine.UI;

public class DifficultManger : MonoBehaviour
{
    public Toggle easyToggle;
    public Toggle normalToggle;
    public Toggle hardToggle;

    private string currentDifficulty = "Easy";

    private void Awake()
    {
        easyToggle.onValueChanged.AddListener(isOn => { if (isOn) SelectDifficulty("Easy"); });
        normalToggle.onValueChanged.AddListener(isOn => { if (isOn) SelectDifficulty("Normal"); });
        hardToggle.onValueChanged.AddListener(isOn => { if (isOn) SelectDifficulty("Hard"); });
    }
    private void Start()
    {
        // 게임 시작 시 자동 저장 파일 불러오기
        if (SaveLoadManager.Load(0))
        {
            var data = SaveLoadManager.Data;
            currentDifficulty = data.Difficulty;

            // 불러온 난이도로 토글 상태 초기화
            switch (data.Difficulty)
            {
                case "Easy": easyToggle.isOn = true; break;
                case "Normal": normalToggle.isOn = true; break;
                case "Hard": hardToggle.isOn = true; break;
            }

            Debug.Log($"게임 시작 시 불러온 난이도: {data.Difficulty}");
        }
    }
    private void Update()
    {
        // S 키 → 저장
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveDifficulty();
        }

        // L 키 → 불러오기 테스트
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (SaveLoadManager.Load(0)) // 슬롯 0 (Auto)
            {
                var data = SaveLoadManager.Data;
                Debug.Log($" 불러온 난이도: {data.Difficulty}");
                ApplyDifficulty(data.Difficulty);

            }
        }
    }

    private void SelectDifficulty(string difficulty)
    {
        currentDifficulty = difficulty;
        Debug.Log($"난이도 선택됨: {difficulty}");
    }
    private void ApplyDifficulty(string difficulty)
    {
        switch (difficulty)
        {
            case "Easy": easyToggle.isOn = true; break;
            case "Normal": normalToggle.isOn = true; break;
            case "Hard": hardToggle.isOn = true; break;
        }
        currentDifficulty = difficulty;
    }
    private void SaveDifficulty()
    {
        if (SaveLoadManager.Data == null)
            SaveLoadManager.Data = new SaveDataV4();

        SaveLoadManager.Data.Difficulty = currentDifficulty;
        SaveLoadManager.Save(0); // 슬롯 0 저장

        Debug.Log($" 저장 완료: {currentDifficulty}");
    }
}
