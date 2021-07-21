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
    /// Data that each single item contains
    /// </summary>
    [System.Serializable]
    public class Item
    {
        /// <summary>
        /// 
        /// </summary>
        public ItemType itemType;

        /// <summary>
        /// 
        /// </summary>
        public string color;
        
        /// <summary>
        /// 
        /// </summary>
        public int points;
    }
}