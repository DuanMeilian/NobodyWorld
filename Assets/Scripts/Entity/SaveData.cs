using System;
using UnityEngine;

/// <summary>
/// �浵��Ϣ
/// </summary>
// �����[System.Serializable]���ܱ�Json���л�
[System.Serializable]
public class SaveData
{
    public string latestSaveTime;//���¸��µ�ǰ�浵ʱ��
    public int health; // ��ֵ
    public int day;// �ڼ���
    public string dialogueID;//�Ի�ID
    public string partnerName;//�����
    public string playerName; // �������
    //public List<Dialogue> storyChoices; // ����ѡ��
    public int saveSlot; // �浵��λ�����ڶ�浵��
}