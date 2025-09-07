using UnityEngine;

/// <summary>
/// 设置信息
/// </summary>
// 必须加[System.Serializable]才能被Json序列化
[System.Serializable]
public class SettingData
{
    //语言
    public string language;

    //已存储存档数量
    public int saveDataTotal;
}
