using UnityEngine;

/// <summary>
/// ������Ϣ������ģʽ��
/// </summary>
public class SettingManager : MonoBehaviour
{
    // ������̬���ԣ������ط���ͨ�� SettingManager.instance �����������
    public static SettingManager instance { get; private set; }

    const string SETTING_DATA_KEY = "Setting";

    // �Ѵ洢�浵����
    public int saveDataTotal { get; private set; }

    // ����
    public string language { get; private set; }

    #region ���õ���
    void Awake()
    {
        // ���ʵ���Ƿ��Ѿ�����
        if (instance != null && instance != this)
        {
            // ����Ѿ�����һ��ʵ��������������´����ĸ�����ȷ��ֻ��һ��ʵ�����ڡ�
            Destroy(gameObject);
        }
        else
        {
            // ��������ڣ����Լ���Ϊʵ���������Ϊ�糡�������١�
            instance = this;
            DontDestroyOnLoad(gameObject);

            // ��������й������ĳ�ʼ����������ش浵����ʼ�����ݣ�
            InitializeGame();
        }
    }
    #endregion

    /// <summary>
    /// ��ʼ����Ϣ
    /// </summary>
    private void InitializeGame()
    {
        //��ʼ������
        saveDataTotal = 0;
        language = "��������";
    }

    #region Method:�洢�Լ���ȡ�趨��Ϣ
    /// <summary>
    /// ����PlayerPrefs�洢�趨��Ϣ
    /// </summary>
    public void SaveSettingData()
    {
        SettingData settingData = new();
        settingData.language = language;
        settingData.saveDataTotal = saveDataTotal;

        Unitity.SaveByPlayerPrefs(SETTING_DATA_KEY, settingData);
    }

    /// <summary>
    /// ����PlayerPrefs��ȡ�趨��Ϣ
    /// </summary>
    public void LoadSettingData()
    {
        var json = Unitity.LoadFromPlayerPrefs(SETTING_DATA_KEY);
        var settingData = JsonUtility.FromJson<SettingData>(json);

        if (settingData != null)
        {
            language = settingData.language;
            saveDataTotal = settingData.saveDataTotal;
        }
    }
    #endregion

    #region Method:���Ӵ浵����
    /// <summary>
    /// ���Ӵ浵����
    /// </summary>
    /// <param name="points">���Ӽ���</param>
    public void AddSaveDataNum(int num)
    {
        saveDataTotal += num;
    }
    #endregion
}
