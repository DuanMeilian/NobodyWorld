using System;
using UnityEngine;

public class Unitity : MonoBehaviour
{

    /// <summary>
    /// 第一次读取设置信息
    /// </summary>
    public static void LoadSettingFirst(SaveManager manager, SettingData settingData)
    {
        //判断是否是第一次进入游戏（通过获取既有存档来判断，如果为null则是第一次进入游戏）
        SaveData saveData = manager.LoadData(1);
        if (saveData == null)
        {
            //创建一个初始的设置内容
            settingData.SaveByPlayerPrefs();
        }
        //不是第一次进入游戏则读取既有的设置信息（存储在注册表中）
        else
        {
            settingData.LoadFromPlayerPrefs();
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
