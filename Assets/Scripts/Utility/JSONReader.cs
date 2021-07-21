using UnityEngine;
using Items.Core;

/// <summary>
/// 
/// </summary>
public static class JSONReader
{
    public static ItemsDB ReadItemsFromJson(TextAsset jsonFile)
    {
        ItemsDB itemsJson = JsonUtility.FromJson<ItemsDB>(jsonFile.text);

        foreach (var item in itemsJson.GetItems())
        {
            Debug.Log($"Found item: {item.points}, {item.color}");
        }

        return itemsJson;
    }
}
