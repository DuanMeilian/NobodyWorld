using System;
using UnityEngine;

public class Unitity : MonoBehaviour
{

    #region 将设置数据存取到注册表
    /// <summary>
    /// 通过JsonUtility将data数据转为json字符串后存储到注册表中
    /// </summary>
    /// <param name="key">键名（Setting）</param>
    /// <param name="data">Setting实例</param>
    public static void SaveByPlayerPrefs(string key, object data)
    {
        var json = JsonUtility.ToJson(data);

        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// 从注册表中读取现有存档
    /// </summary>
    /// <param name="key">键名（Setting）</param>
    /// <returns>现有设定数据</returns>
    public static string LoadFromPlayerPrefs(string key)
    {
        return PlayerPrefs.GetString(key, null);
    }

    /// <summary>
    /// 删除注册表所有创建的键值，并显示在编辑器菜单栏上
    /// </summary>
    [UnityEditor.MenuItem("Developer/Delete Player Data Prefs")]
    public static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
    #endregion

    /// <summary>
    /// 第一次读取设置信息
    /// </summary>
    public static void LoadSettingFirst(SaveManager manager, SettingManager settingManager)
    {
        //判断是否是第一次进入游戏（通过获取既有存档来判断，如果为null则是第一次进入游戏）
        SaveData saveData = manager.LoadData(1);
        if (saveData == null)
        {
            //创建一个初始的设置内容
            settingManager.SaveSettingData();
        }
        //不是第一次进入游戏则读取既有的设置信息（存储在注册表中）
        else
        {
            settingManager.LoadSettingData();
        }
    }

    /// <summary>
    /// 删除ob下的所有子对象
    /// </summary>
    public static void DeleteChildren(GameObject ob)
    {
        for (int i = 0; i < ob.transform.childCount; i++)
        {
            Destroy(ob.transform.GetChild(i).gameObject);
        }
    }
}
