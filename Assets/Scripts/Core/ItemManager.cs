using System;
using System.Collections.Generic;
using Items.Core;
using Snake.Gameplay;
using UnityEngine;
using Utility;
using Random = UnityEngine.Random;

namespace Core
{
    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class SpawnBoundaries
    {
        public Vector2 LeftTopCorner;
        public Vector2 RightTopCorner;
        public Vector2 LeftBottomCorner;
        public Vector2 RightBottomCorner;
    }

    /// <summary>
    /// 
    /// </summary>
    [System.Serializable]
    public class ItemPrefab
    {
        public ItemType Type;
        public ItemColor Color;
        public GameObject Prefab;
    }
    
    /// <summary>
    /// 
    /// </summary>
    public class ItemManager : MonoBehaviour
    {
        #region Variables

        /// <summary>
        /// 
        /// </summary>
        [Header("Spawn Information")] 
        [Tooltip("")] [SerializeField] private SpawnBoundaries spawnArea;
        
        /// <summary>
        /// 
        /// </summary>
        [Tooltip("")][SerializeField] private List<ItemPrefab> itemPrefabsDictionary;
        
        /// <summary>
        /// 
        /// </summary>
        [Space(10)]
        [SerializeField] private TextAsset jsonItemsFile;

        /// <summary>
        /// 
        /// </summary>
        private ItemsDB _itemsDB;

        #endregion
        
        #region Methods

        /// <summary>
        /// 
        /// </summary>
        private void Start()
        {
            ItemDelegates.onItemDestroy += SpawnRandomItem;
            
            _itemsDB = JSONReader.ReadItemsFromJson(jsonItemsFile);

            SpawnRandomItem();
        }

        private void OnDestroy()
        {
            ItemDelegates.onItemDestroy -= SpawnRandomItem;
        }

        #region Item Spawn

        private void SpawnRandomItem()
        {
            Debug.Log("Spawn item");
            
            var obj = _itemsDB.GetItemAt(Random.Range(0, _itemsDB.items.Count));
            foreach (var item in itemPrefabsDictionary)
            {
                if (item.Color == obj.color && item.Type == obj.itemType)
                {
                    Vector3 pointOne = GetRandomPointBetweenVectors(
                        new Vector3(spawnArea.LeftBottomCorner.x, 0f, spawnArea.LeftBottomCorner.y),
                        new Vector3(spawnArea.LeftTopCorner.x, 0f, spawnArea.LeftTopCorner.y));

                    Vector3 pointTwo = GetRandomPointBetweenVectors(
                        new Vector3(spawnArea.RightBottomCorner.x, 0f, spawnArea.RightBottomCorner.y),
                        new Vector3(spawnArea.RightTopCorner.x, 0f, spawnArea.RightTopCorner.y));

                    Vector3 spawnPosition = GetRandomPointBetweenVectors(pointOne, pointTwo);

                    // Increasing the height by 0.5f to not be stuck in the ground
                    var newItem = Instantiate(item.Prefab, new Vector3(spawnPosition.x, 0.5f, spawnPosition.z), Quaternion.identity);
                    
                    // Setting data of an item to the instance
                    newItem.GetComponent<ItemMonoObject>().SetData(obj);
                }
            }
        }

        private Vector3 GetRandomPointBetweenVectors(Vector3 firstVector, Vector3 secondVector)
        {
            return secondVector + Vector3.Normalize(firstVector - secondVector) * Random.Range(0f, Vector3.Distance(firstVector, secondVector));
        }

        #endregion

        #region Multi-levels & Multi-files load implementation

        private void Awake()
        {
            // The structure of the game should be easily expandable and I feel like the architecture of an ItemManager
            // needs a brief explanation from me.
            //
            // If there are multiple levels - current ItemManager script can be expanded to use a List<TextAsset> instead
            // of a single asset and when there is a need to load next level - call LoadItemsFromJsonForLevel that will
            // load items from according jsonLevel that will contain items for specific level.
            // 
            // If we need an ItemManager to also include items from previous levels in new levels - we can either use
            // DontDestroyOnLoad on this Game Object or use Singleton pattern with small changes to ensure ItemManager
            // is always exists in the Level
        }

        // In case if there are multiple levels with different items for each level - this method would load items
        // from appropriate text asset
        // public void LoadItemsFromJsonForLevel(int levelIndex)
        // {
        //     // If items database has to be wiped
        //     _itemsDB = JSONReader.ReadItemsFromJson(jsonDB[levelIndex]);
        //
        //     // If items database has to be saved - add a for loop that will add to current items database
        // }

        #endregion

        #endregion
    }
}
