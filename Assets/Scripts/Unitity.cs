using System;
using UnityEngine;

public class Unitity : MonoBehaviour
{

    #region ���������ݴ�ȡ��ע���
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
    #endregion

    /// <summary>
    /// ��һ�ζ�ȡ������Ϣ
    /// </summary>
    public static void LoadSettingFirst(SaveManager manager, SettingManager settingManager)
    {
        //�ж��Ƿ��ǵ�һ�ν�����Ϸ��ͨ����ȡ���д浵���жϣ����Ϊnull���ǵ�һ�ν�����Ϸ��
        SaveData saveData = manager.LoadData(1);
        if (saveData == null)
        {
            //����һ����ʼ����������
            settingManager.SaveSettingData();
        }
        //���ǵ�һ�ν�����Ϸ���ȡ���е�������Ϣ���洢��ע����У�
        else
        {
            settingManager.LoadSettingData();
        }
    }

    /// <summary>
    /// ɾ��ob�µ������Ӷ���
    /// </summary>
    public static void DeleteChildren(GameObject ob)
    {
        for (int i = 0; i < ob.transform.childCount; i++)
        {
            Destroy(ob.transform.GetChild(i).gameObject);
        }
    }
}
