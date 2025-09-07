using UnityEngine;

/// <summary>
/// 设置信息（单例模式）
/// </summary>
public class SettingData : MonoBehaviour
{
    const string SETTING_DATA_KEY = "Setting";

    //已存储存档数量
    public int saveDataTotal = 0;

    // 语言
    public string language = "简体中文";

    #region 设置单例
    private SettingData instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    // 必须添加可序列化，否则JsonUnility无法将其转换
    [System.Serializable]
    class SaveData
    {
        public string language;
        public int saveDataTotal;
    }

    #region PlayerPrefs

    /// <summary>
    /// 利用PlayerPrefs存档
    /// </summary>
    public void SaveByPlayerPrefs()
    {
        var saveData = new SaveData();
        saveData.language = language;
        saveData.saveDataTotal = saveDataTotal;

        SettingSaveSystem.SaveByPlayerPrefs(SETTING_DATA_KEY, saveData);
    }

    /// <summary>
    /// 利用PlayerPrefs读档
    /// </summary>
    public void LoadFromPlayerPrefs()
    {
        var json = SettingSaveSystem.LoadFromPlayerPrefs(SETTING_DATA_KEY);
        var saveData = JsonUtility.FromJson<SaveData>(json);

        if (saveData != null)
        {
            language = saveData.language;
            saveDataTotal = saveData.saveDataTotal;
        }
    }
    #endregion
}
