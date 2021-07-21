using System.Collections.Generic;
using UnityEngine;

namespace Items.Core
{
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class ItemsDB
    {
        #region Variables

        /// <summary>
        /// 
        /// </summary>
        private List<Item> items = new List<Item>();

        #endregion

        #region Methods

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Item> GetItems() => items;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public Item GetItemAt(int index) => items[index];

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void AddItem(Item item) => items.Add(item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        public void RemoveItemAt(Item item) => items.Remove(item);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void RemoveItemAt(int index) => items.RemoveAt(index);

        #endregion
    }
}
