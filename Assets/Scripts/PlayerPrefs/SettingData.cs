using UnityEngine;

/// <summary>
/// ������Ϣ������ģʽ��
/// </summary>
public class SettingData : MonoBehaviour
{
    const string SETTING_DATA_KEY = "Setting";

    //�Ѵ洢�浵����
    public int saveDataTotal = 0;

    // ����
    public string language = "��������";

    #region ���õ���
    private SettingData instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    // ������ӿ����л�������JsonUnility�޷�����ת��
    [System.Serializable]
    class SaveData
    {
        public string language;
        public int saveDataTotal;
    }

    #region PlayerPrefs

    /// <summary>
    /// ����PlayerPrefs�浵
    /// </summary>
    public void SaveByPlayerPrefs()
    {
        var saveData = new SaveData();
        saveData.language = language;
        saveData.saveDataTotal = saveDataTotal;

        SettingSaveSystem.SaveByPlayerPrefs(SETTING_DATA_KEY, saveData);
    }

    /// <summary>
    /// ����PlayerPrefs����
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
