using NUnit.Framework.Interfaces;
using System.Data;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

[ExecuteInEditMode]
public enum TableType
{
    String, // 기존 다국어 문자열
    Items   // 아이템 전용 테이블
}
[RequireComponent(typeof(TextMeshProUGUI))]
public class LocalizationText : MonoBehaviour
{
    public string stringId;
    public TableType tableType = TableType.String;

#if UNITY_EDITOR
    public Languages editorLang;
#endif

    private TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void OnEnable()
    {
#if UNITY_EDITOR
        if (Application.isPlaying)
        {
            OnChangeLanguage();
        }
        else
        {
            OnChangeLanguage(editorLang);
        }
#else
        OnChangeLanguage();
#endif
    }

    public void OnChangeLanguage()
    {
        if (tableType == TableType.String)
        {
            var stringTable = DataTableManager.stringTable;
            text.text = stringTable.Get(stringId);
        }
        else if (tableType == TableType.Items)
        {
            var itemTable = DataTableManager.Get<ItemTable>(DataTableIds.ItemsTableId);
            //text.text = text.text = itemData.Name; // Items 테이블에서 ID 매칭
        }
    }
#if UNITY_EDITOR
    public void OnChangeLanguage(Languages lang)
    {
        if (tableType == TableType.String)
        {
            var tableId = DataTableIds.StringTableIds[(int)lang];
            var stringTable = DataTableManager.Get<StringTable>(tableId);
            text.text = stringTable.Get(stringId);
        }
        else if (tableType == TableType.Items)
        {
            var itemTable = DataTableManager.Get<ItemTable>(DataTableIds.ItemsTableId);
            //text.text = itemTable.Get(stringId);
        }
    }
#endif
}
