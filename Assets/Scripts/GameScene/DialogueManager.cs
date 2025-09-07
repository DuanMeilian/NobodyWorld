using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    //�浵����
    public SaveManager manager;

    //�趨����
    public SettingData settingData;

    //��ͨ�����ļ�
    public TextAsset commonFile;

    //�Ի���Ϣ�����ڷ�Χ
    public Transform dialogueTransform;

    // һ��ʫ����Ϣ
    public GameObject dialogueData;

    //�浵��Ϣ
    private SaveData saveData;

    void Start()
    {
        //��ȡ������Ϣ
        settingData.LoadFromPlayerPrefs();
        //��ȡ�浵
        saveData = manager.LoadData(settingData.saveDataTotal);

        //��ǰ��ҵĽ��ȴ��ڵ�1~5��
        if (saveData.day > 0 && saveData.day < 6) 
        {
            LoadTodayFirstMeg();
        }
    }

    /// <summary>
    /// ��ȡ����ĵ�һ���Ի������ڵ�1~5�죩
    /// </summary>
    private void LoadTodayFirstMeg()
    {
        Unitity.DeleteChildren(dialogueTransform.gameObject);
        string[] textLines = commonFile.text.Split('\n');
        for (int i = 1; i < textLines.Length - 1; i++)
        {
            GameObject dialogueDataClone = Instantiate(dialogueData, dialogueTransform);

        }
    }
}