using UnityEngine;

/// <summary>
/// ʱ��Ի�����ģ�ͣ���ӦCommon.csv��һ�У�
/// </summary>
[System.Serializable]
public class DialogueText : MonoBehaviour
{

    //�Ի�ID
    public string dialogueID;

    //����
    public int day;

    //˵������
    public string speaker;

    //��֧����
    public string branchType;

    //����ľ������
    public int sentenceIndex;

    //�ı�����
    public int content;

    //��ӷ�֧ID
    public string branchTriggerID;

    //���ID
    public string endingID;
}
