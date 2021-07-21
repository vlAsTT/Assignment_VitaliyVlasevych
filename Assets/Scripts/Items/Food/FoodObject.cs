using Items.Core;
using UnityEngine;

namespace Items.Food
{
    /// <summary>
    /// 
    /// </summary>
    public class FoodObject : MonoBehaviour
    {
        /// <summary>
        /// 
        /// </summary>
        private Item _data;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Item GetData() => _data;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public void SetData(Item data) => _data = data;
    }
}
