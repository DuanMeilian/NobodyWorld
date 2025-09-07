using UnityEngine;

/// <summary>
/// ���������ݴ洢��ע���
/// </summary>
public static class SettingSaveSystem
{ 
    /// <summary>
    /// ͨ��JsonUtility��data����תΪjson�ַ�����洢��ע�����
    /// </summary>
    /// <param name="key">������Setting��</param>
    /// <param name="data">Settingʵ��</param>
    public static void SaveByPlayerPrefs(string key, object data)
    {
        var json = JsonUtility.ToJson(data);

        PlayerPrefs.SetString(key, json);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// ��ע����ж�ȡ���д浵
    /// </summary>
    /// <param name="key">������Setting��</param>
    /// <returns>�����趨����</returns>
    public static string LoadFromPlayerPrefs(string key)
    {
        return PlayerPrefs.GetString(key, null);
    }

    /// <summary>
    /// ɾ��ע������д����ļ�ֵ������ʾ�ڱ༭���˵�����
    /// </summary>
    [UnityEditor.MenuItem("Developer/Delete Player Data Prefs")]
    public static void DeletePlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
