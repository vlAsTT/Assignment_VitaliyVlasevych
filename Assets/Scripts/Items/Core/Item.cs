using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Items.Core
{
    /// <summary>
    /// All types of items available in the game
    /// </summary>
    public enum ItemType
    {
        Default = 0,
        Food
    }

    public enum ItemColor
    {
        Default = 0,
        Red,
        Blue
    }

    /// <summary>
    /// Data that each single item contains
    /// </summary>
    [System.Serializable]
    public class Item
    {
        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemType itemType;

        /// <summary>
        /// 
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemColor color;
        
        /// <summary>
        /// 
        /// </summary>
        public int points;
    }
}