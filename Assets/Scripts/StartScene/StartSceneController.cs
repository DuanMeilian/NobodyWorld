using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    //存档管理
    public SaveManager manager;

    //设定数据
    public SettingData settingData;

    void Start()
    {
        Unitity.LoadSettingFirst(manager, settingData);
    }

    #region 读取指定场景
    /// <summary>
    /// 加载指定名称的场景
    /// （可用于代码中直接调用）
    /// </summary>
    /// <param name="sceneName">场景名称</param>
    public void LoadScene(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("场景名称不能为空");
            return;
        }

        try
        {
            SceneManager.LoadScene(sceneName);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"加载场景失败: {e.Message}");
        }
    }
    #endregion

    #region 从第一天开始按钮事件
    /// <summary>
    /// 创建一个初始化的玩家数据
    /// （用在【从第一天开始】按钮上）
    /// </summary>
    public void NewInitialPlayer() 
    {
        //存储玩家数据
        SaveData saveData = new();
        saveData.health = 100;
        saveData.saveSlot = settingData.saveDataTotal + 1;
        saveData.day = 1;
        manager.SaveData(saveData, saveData.saveSlot);

        //将已使用存档数量加1
        settingData.saveDataTotal++;
        settingData.SaveByPlayerPrefs();
    }
    #endregion

    public void InitLoadGameScreenInfo() {
        //将已有的存档数据全都读到saveDataList集合中
        List<SaveData> saveDataList = new();
        for (int i = 1; i <= settingData.saveDataTotal; i++) {
            SaveData saveData = manager.LoadData(i);
            saveDataList.Add(saveData);
        }
    }

    #region Exit按钮事件
    /// <summary>
    /// 关闭游戏
    /// （用在【Exit】按钮上）
    /// </summary>
    public void QuitGame()
    {
        //在编辑器模式下关闭应用程序
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        //在运行时关闭应用程序（适用于构建后的应用程序）
        #else
            Application.Quit();
        #endif
    }
    #endregion
}