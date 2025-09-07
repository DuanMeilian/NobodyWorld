using System;
using UnityEngine;

/// <summary>
/// 存档信息
/// </summary>
// 必须加[System.Serializable]才能被Json序列化
[System.Serializable]
public class SaveData
{
    public string latestSaveTime;//最新更新当前存档时间
    public int health; // 火值
    public int day;// 第几天
    public string dialogueID;//对话ID
    public string partnerName;//伙伴名
    public string playerName; // 玩家名称
    //public List<Dialogue> storyChoices; // 剧情选择
    public int saveSlot; // 存档槽位（用于多存档）
}