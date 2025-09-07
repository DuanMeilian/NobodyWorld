using System;
using UnityEngine;

public class Unitity : MonoBehaviour
{

    /// <summary>
    /// ��һ�ζ�ȡ������Ϣ
    /// </summary>
    public static void LoadSettingFirst(SaveManager manager, SettingData settingData)
    {
        //�ж��Ƿ��ǵ�һ�ν�����Ϸ��ͨ����ȡ���д浵���жϣ����Ϊnull���ǵ�һ�ν�����Ϸ��
        SaveData saveData = manager.LoadData(1);
        if (saveData == null)
        {
            //����һ����ʼ����������
            settingData.SaveByPlayerPrefs();
        }
        //���ǵ�һ�ν�����Ϸ���ȡ���е�������Ϣ���洢��ע����У�
        else
        {
            settingData.LoadFromPlayerPrefs();
        }
    }

    /// <summary>
    /// ɾ��ob�µ������Ӷ���
    /// </summary>
    public static void DeleteChildren(GameObject ob)
    {
        for (int i = 0; i < ob.transform.childCount; i++)
        {
            Destroy(ob.transform.GetChild(i).gameObject);
        }
    }


}
