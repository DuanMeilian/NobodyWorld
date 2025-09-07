using System.IO;
using UnityEngine;

/// <summary>
/// 存档系统
/// </summary>
public class SaveManager : MonoBehaviour
{
    // 存档文件路径（Application.persistentDataPath是Unity推荐的持久化路径）
    private string GetSavePath(int slot)
    {
        return Path.Combine(Application.persistentDataPath, $"save_{slot}.json");
    }

    // 保存数据到指定存档槽
    public void SaveData(SaveData data, int slot)
    {
        // 转为Json字符串（注意：JsonUtility不支持Dictionary，需用List替代或用第三方库如Newtonsoft.Json）
        string json = JsonUtility.ToJson(data, true); // true：格式化输出，方便调试
        // 写入文件
        File.WriteAllText(GetSavePath(slot), json);
        Debug.Log($"存档成功：{GetSavePath(slot)}");
    }

    // 从指定存档槽加载数据
    public SaveData LoadData(int slot)
    {
        string path = GetSavePath(slot);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            return JsonUtility.FromJson<SaveData>(json);
        }
        Debug.LogWarning($"存档不存在：{path}");
        return null;
    }

    // 删除指定存档
    public void DeleteSave(int slot)
    {
        string path = GetSavePath(slot);
        if (File.Exists(path))
        {
            File.Delete(path);
            Debug.Log($"删除存档：{path}");
        }
    }
}