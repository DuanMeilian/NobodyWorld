using UnityEngine;

/// <summary>
/// 结局数据模型（对应Ending.csv的一行）
/// </summary>
[System.Serializable]
public class Ending : MonoBehaviour
{
    //结局ID
    public string endingID;

    //结局名
    public string endingName;

    //结局内容
    public string content;
}
