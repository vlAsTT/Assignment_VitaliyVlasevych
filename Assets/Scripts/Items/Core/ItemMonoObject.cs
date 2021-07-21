using UnityEngine;

namespace Items.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemMonoObject : MonoBehaviour
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
