using Items.Core;
using Newtonsoft.Json;
using UnityEngine;

namespace Utility
{
    /// <summary>
    /// Set of methods that reads from JSON files and returns appropriate information parsed & ready-to-use
    /// </summary>
    public static class JSONReader
    {
        /// <summary>
        /// Parses JSON file and returns all items retrieved from there
        /// </summary>
        /// <param name="jsonFile">JSON Items File</param>
        /// <returns>List of items obtained from parsing a JSON file</returns>
        /// <seealso cref="ItemsDB"/>
        public static ItemsDB ReadItemsFromJson(TextAsset jsonFile)
        {
            ItemsDB itemsJson = JsonConvert.DeserializeObject<ItemsDB>(jsonFile.text);

            return itemsJson;
        }
    }
}
