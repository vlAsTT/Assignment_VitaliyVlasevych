using Items.Core;
using UnityEngine;

namespace Core
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemManager : MonoBehaviour
    {
        #region Variables

        /// <summary>
        /// 
        /// </summary>
        [SerializeField] private TextAsset jsonFile;

        private ItemsDB _itemsDB;

        #endregion
        
        #region Methods

        private void Start()
        {
            _itemsDB = JSONReader.ReadItemsFromJson(jsonFile);
            
            Debug.Log($"Items Length: {_itemsDB.GetItems().Count}");
        }

        #endregion
    }
}
