using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // 公共静态属性，其他地方都通过 GameManager.instance 访问这个单例
    public static GameManager instance { get; private set; }

    // 存档管理
    private SaveManager saveManager;

    //设定管理
    private SettingManager settingManager;

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
        saveManager = SaveManager.instance;
        settingManager = SettingManager.instance;

        if (saveManager != null && settingManager != null)
        {
            Debug.Log("GameManager变量初始化成功");
        }
        else
        {
            Debug.Log("GameManager变量初始化失败");
            return;
        }

        //读取设定信息
        Unitity.LoadSettingFirst(saveManager, settingManager);

        //跳转到开始游戏界面，并配合一个加载界面（进度条或旋转的图标）
        SceneManager.LoadSceneAsync(1);
    }
}
