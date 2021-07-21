using Items.Core;
using Newtonsoft.Json;
using UnityEngine;

namespace Utility
{
    /// <summary>
    /// 
    /// </summary>
    public static class JSONReader
    {
        public static ItemsDB ReadItemsFromJson(TextAsset jsonFile)
        {
            ItemsDB itemsJson = JsonConvert.DeserializeObject<ItemsDB>(jsonFile.text);

            return itemsJson;
        }
    }
}
