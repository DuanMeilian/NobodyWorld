using UnityEngine;

public class DialogueManager : MonoBehaviour
{

    //存档管理
    public SaveManager manager;

    //设定数据
    public SettingData settingData;

    //共通剧情文件
    public TextAsset commonFile;

    //对话信息的所在范围
    public Transform dialogueTransform;

    // 一张诗牌信息
    public GameObject dialogueData;

    //存档信息
    private SaveData saveData;

    void Start()
    {
        //读取设置信息
        settingData.LoadFromPlayerPrefs();
        //读取存档
        saveData = manager.LoadData(settingData.saveDataTotal);

        //当前玩家的进度处于第1~5天
        if (saveData.day > 0 && saveData.day < 6) 
        {
            LoadTodayFirstMeg();
        }
    }

    /// <summary>
    /// 读取今天的第一条对话（用在第1~5天）
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