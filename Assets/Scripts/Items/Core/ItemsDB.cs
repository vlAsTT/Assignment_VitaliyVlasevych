using System.Collections.Generic;

namespace Items.Core
{
    /// <summary>
    /// Database that contains items
    /// </summary>
    /// <seealso cref="Item"/>
    [System.Serializable]
    public class ItemsDB
    {
        /// <summary>
        /// List of Items
        /// </summary>
        /// <seealso cref="Item"/>
        public List<Item> items = new List<Item>();
    }
}
