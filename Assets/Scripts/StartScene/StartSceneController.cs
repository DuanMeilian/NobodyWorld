using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneController : MonoBehaviour
{
    //�浵����
    public SaveManager manager;

    //�趨����
    public SettingData settingData;

    void Start()
    {
        Unitity.LoadSettingFirst(manager, settingData);
    }

    #region ��ȡָ������
    /// <summary>
    /// ����ָ�����Ƶĳ���
    /// �������ڴ�����ֱ�ӵ��ã�
    /// </summary>
    /// <param name="sceneName">��������</param>
    public void LoadScene(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName))
        {
            Debug.LogError("�������Ʋ���Ϊ��");
            return;
        }

        try
        {
            SceneManager.LoadScene(sceneName);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"���س���ʧ��: {e.Message}");
        }
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
        saveData.saveSlot = settingData.saveDataTotal + 1;
        saveData.day = 1;
        manager.SaveData(saveData, saveData.saveSlot);

        //����ʹ�ô浵������1
        settingData.saveDataTotal++;
        settingData.SaveByPlayerPrefs();
    }
    #endregion

    public void InitLoadGameScreenInfo() {
        //�����еĴ浵����ȫ������saveDataList������
        List<SaveData> saveDataList = new();
        for (int i = 1; i <= settingData.saveDataTotal; i++) {
            SaveData saveData = manager.LoadData(i);
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