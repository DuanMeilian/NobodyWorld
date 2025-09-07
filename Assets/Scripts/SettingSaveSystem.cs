using UnityEngine;

/// <summary>
/// 将设置数据存储到注册表
/// </summary>
public static class SettingSaveSystem
{ 
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
}
