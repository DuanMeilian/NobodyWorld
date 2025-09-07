using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    //�浵����
    private SaveManager saveManager;

    //�趨����
    private SettingManager settingManager;

    void Awake()
    {
        saveManager = SaveManager.instance;
        settingManager = SettingManager.instance;
    }

    #region ��ȡָ������
    /// <summary>
    /// ����ָ�����Ƶĳ���
    /// �������ڴ�����ֱ�ӵ��ã�
    /// </summary>
    /// <param name="sceneName">��������</param>
    public void LoadScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }
    #endregion

    #region �ӵ�һ�쿪ʼ��ť�¼�
    /// <summary>
    /// ����һ����ʼ�����������
    /// �����ڡ��ӵ�һ�쿪ʼ����ť�ϣ�
    /// </summary>
    public void NewInitialPlayer() 
    {
        //�洢�������
        SaveData saveData = new();
        saveData.health = 100;
        saveData.saveSlot = settingManager.saveDataTotal + 1;
        saveData.day = 1;
        saveManager.SaveData(saveData, saveData.saveSlot);

        //����ʹ�ô浵������1
        settingManager.AddSaveDataNum(1);
        settingManager.SaveSettingData();
    }
    #endregion

    public void InitLoadGameScreenInfo() {
        //�����еĴ浵����ȫ������saveDataList������
        List<SaveData> saveDataList = new();
        for (int i = 1; i <= settingManager.saveDataTotal; i++) {
            SaveData saveData = saveManager.LoadData(i);
            saveDataList.Add(saveData);
        }
    }

    #region Exit��ť�¼�
    /// <summary>
    /// �ر���Ϸ
    /// �����ڡ�Exit����ť�ϣ�
    /// </summary>
    public void QuitGame()
    {
        //�ڱ༭��ģʽ�¹ر�Ӧ�ó���
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        //������ʱ�ر�Ӧ�ó��������ڹ������Ӧ�ó���
        #else
            Application.Quit();
        #endif
    }
    #endregion
}