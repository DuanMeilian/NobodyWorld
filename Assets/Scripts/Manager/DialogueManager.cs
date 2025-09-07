using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    //�浵����
    private SaveManager saveManager;

    //�趨����
    private SettingManager settingManager;

    //��ͨ�����ļ�
    public TextAsset commonFile;

    //�Ի���Ϣ�����ڷ�Χ
    public Transform dialogueTransform;

    // һ��ʫ����Ϣ
    public GameObject dialogueData;

    //�浵��Ϣ
    private SaveData saveData;

    void Awake()
    {
        saveManager = SaveManager.instance;
        settingManager = SettingManager.instance;
    }

    void Start()
    {
        //��ȡ������Ϣ
        settingManager.LoadSettingData();
        //��ȡ�浵
        saveData = saveManager.LoadData(settingManager.saveDataTotal);

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