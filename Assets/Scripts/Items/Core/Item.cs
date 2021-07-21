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

    /// <summary>
    /// All colors of items available in the game
    /// </summary>
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
        /// Type of the item
        /// </summary>
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemType itemType;

        /// <summary>
        /// Color if the item
        /// </summary>n
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemColor color;
        
        /// <summary>
        /// Points that item gives on pickup
        /// </summary>
        public int points; // Could possibly be extracted in the new ItemFood class that will inherit from Item
    }
}