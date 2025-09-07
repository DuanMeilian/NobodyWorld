using UnityEngine;

/// <summary>
/// 时序对话数据模型（对应Common.csv的一行）
/// </summary>
[System.Serializable]
public class DialogueText : MonoBehaviour
{

    //对话ID
    public string dialogueID;

    //天数
    public int day;

    //说话对象
    public string speaker;

    //分支种类
    public string branchType;

    //当天的句子序号
    public int sentenceIndex;

    //文本内容
    public int content;

    //后接分支ID
    public string branchTriggerID;

    //结局ID
    public string endingID;
}
