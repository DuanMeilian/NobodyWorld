using System.IO;
using UnityEngine;

/// <summary>
/// �浵ϵͳ
/// </summary>
public class SaveManager : MonoBehaviour
{
    // �浵�ļ�·����Application.persistentDataPath��Unity�Ƽ��ĳ־û�·����
    private string GetSavePath(int slot)
    {
        return Path.Combine(Application.persistentDataPath, $"save_{slot}.json");
    }

    // �������ݵ�ָ���浵��
    public void SaveData(SaveData data, int slot)
    {
        // תΪJson�ַ�����ע�⣺JsonUtility��֧��Dictionary������List������õ���������Newtonsoft.Json��
        string json = JsonUtility.ToJson(data, true); // true����ʽ��������������
        // д���ļ�
        File.WriteAllText(GetSavePath(slot), json);
        Debug.Log($"�浵�ɹ���{GetSavePath(slot)}");
    }

    // ��ָ���浵�ۼ�������
    public SaveData LoadData(int slot)
    {
        string path = GetSavePath(slot);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<SaveData>(json);
        }
        Debug.LogWarning($"�浵�����ڣ�{path}");
        return null;
    }

    // ɾ��ָ���浵
    public void DeleteSave(int slot)
    {
        string path = GetSavePath(slot);
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log($"ɾ���浵��{path}");
        }
    }
}