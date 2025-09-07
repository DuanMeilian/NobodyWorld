using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // ������̬���ԣ������ط���ͨ�� GameManager.instance �����������
    public static GameManager instance { get; private set; }

    // �浵����
    private SaveManager saveManager;

    //�趨����
    private SettingManager settingManager;

    #region ���õ���
    void Awake()
    {
        // ���ʵ���Ƿ��Ѿ�����
        if (instance != null && instance != this)
        {
            // ����Ѿ�����һ��ʵ��������������´����ĸ�����ȷ��ֻ��һ��ʵ�����ڡ�
            Destroy(gameObject);
        }
        else
        {
            // ��������ڣ����Լ���Ϊʵ���������Ϊ�糡�������١�
            instance = this;
            DontDestroyOnLoad(gameObject);

            // ��������й������ĳ�ʼ����������ش浵����ʼ�����ݣ�
            InitializeGame();
        }
    }
    #endregion

    /// <summary>
    /// ��ʼ����Ϣ
    /// </summary>
    private void InitializeGame()
    {
        //��ʼ������
        saveManager = SaveManager.instance;
        settingManager = SettingManager.instance;

        if (saveManager != null && settingManager != null)
        {
            Debug.Log("GameManager������ʼ���ɹ�");
        }
        else
        {
            Debug.Log("GameManager������ʼ��ʧ��");
            return;
        }

        //��ȡ�趨��Ϣ
        Unitity.LoadSettingFirst(saveManager, settingManager);

        //��ת����ʼ��Ϸ���棬�����һ�����ؽ��棨����������ת��ͼ�꣩
        SceneManager.LoadSceneAsync(1);
    }
}
