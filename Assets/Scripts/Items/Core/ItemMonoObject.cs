using UnityEngine;

namespace Items.Core
{
    /// <summary>
    /// MonoBehaviour version of an Item script that is attached on the instantiated prefab containing Item data
    /// </summary>
    public class ItemMonoObject : MonoBehaviour
    {
        /// <summary>
        /// Data of the item
        /// </summary>
        /// <seealso cref="Item"/>
        private Item _data;

        /// <summary>
        /// Getter of an Item Data
        /// </summary>
        /// <returns>Item Data Object</returns>
        /// <seealso cref="_data"/>
        public Item GetData() => _data;

        /// <summary>
        /// Setter of an Item Data
        /// </summary>
        /// <param name="data">New Item Data</param>
        /// <seealso cref="_data"/>
        public void SetData(Item data) => _data = data;
    }
}
