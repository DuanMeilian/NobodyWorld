using UnityEngine;

/// <summary>
/// 剧情分支数据模型（对应CommonBranch.csv的一行）
/// </summary>
[System.Serializable]
public class StoryBranch : MonoBehaviour
{
    //分支ID（如C1）
    public string branchID;

    //分支编号
    public int optionNum;

    //分支内容
    public string content;
}
