using System.Collections.Generic;
using UnityEngine;

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

        /// <summary>
        /// Returns an item at specified index
        /// </summary>
        /// <param name="index">Index of an item in the list</param>
        /// <returns>Item at specified index</returns>
        public Item GetItemAt(int index) => items[index];
    }
}
