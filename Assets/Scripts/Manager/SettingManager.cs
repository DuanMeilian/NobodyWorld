using UnityEngine;

/// <summary>
/// 设置信息（单例模式）
/// </summary>
public class SettingManager : MonoBehaviour
{
    // 公共静态属性，其他地方都通过 SettingManager.instance 访问这个单例
    public static SettingManager instance { get; private set; }

    const string SETTING_DATA_KEY = "Setting";

    // 已存储存档数量
    public int saveDataTotal { get; private set; }

    // 语言
    public string language { get; private set; }

    #region 设置单例
    void Awake()
    {
        // 检查实例是否已经存在
        if (instance != null && instance != this)
        {
            // 如果已经存在一个实例，则销毁这个新创建的副本，确保只有一个实例存在。
            Destroy(gameObject);
        }
        else
        {
            // 如果不存在，则将自己设为实例，并标记为跨场景不销毁。
            instance = this;
            DontDestroyOnLoad(gameObject);

            // 在这里进行管理器的初始化（例如加载存档、初始化数据）
            InitializeGame();
        }
    }
    #endregion

    /// <summary>
    /// 初始化信息
    /// </summary>
    private void InitializeGame()
    {
        //初始化变量
        saveDataTotal = 0;
        language = "简体中文";
    }

    #region Method:存储以及读取设定信息
    /// <summary>
    /// 利用PlayerPrefs存储设定信息
    /// </summary>
    public void SaveSettingData()
    {
        SettingData settingData = new();
        settingData.language = language;
        settingData.saveDataTotal = saveDataTotal;

        Unitity.SaveByPlayerPrefs(SETTING_DATA_KEY, settingData);
    }

    /// <summary>
    /// 利用PlayerPrefs读取设定信息
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

    #region Method:增加存档总数
    /// <summary>
    /// 增加存档总数
    /// </summary>
    /// <param name="points">增加几个</param>
    public void AddSaveDataNum(int num)
    {
        saveDataTotal += num;
    }
    #endregion
}
