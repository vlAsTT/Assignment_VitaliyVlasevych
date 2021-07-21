using System.Collections.Generic;
using Items.Core;
using Snake.Gameplay;
using UnityEngine;
using Utility;
using Random = UnityEngine.Random;

namespace Core
{
    /// <summary>
    /// Boundaries within items can be spawned
    /// Defined via 4 Vector2 that should correspond to points in the world of (X, 0, Z)
    /// </summary>
    [System.Serializable]
    public class SpawnBoundaries
    {
        public Vector2 leftTopCorner;
        public Vector2 rightTopCorner;
        public Vector2 leftBottomCorner;
        public Vector2 rightBottomCorner;
    }

    /// <summary>
    /// Creates a link between data that defines item and according prefab that should be instantiated on runtime
    /// </summary>
    /// <seealso cref="Item"/>
    /// <seealso cref="ItemType"/>
    /// <seealso cref="ItemColor"/>
    [System.Serializable]
    public class ItemPrefab
    {
        public ItemType type;
        public ItemColor color;
        public GameObject prefab;
    }
    
    /// <summary>
    /// Manager that handles all items operations including loading them from json file(s) and spawning
    /// </summary>
    /// <seealso cref="Item"/>
    /// <seealso cref="ItemsDB"/>
    public class ItemManager : MonoBehaviour
    {
        #region Variables

        /// <summary>
        /// Defines a rectangle within of which items can be spawned
        /// </summary>
        /// <seealso cref="SpawnBoundaries"/>
        [Header("Spawn Information")] [Tooltip("Four points in the world that defines an area where items can be spawned")] 
        [SerializeField] private SpawnBoundaries spawnArea;
        
        /// <summary>
        /// Maps core item data to the prefab that should be instantiated
        /// </summary>
        /// <seealso cref="ItemPrefab"/>
        [Tooltip("Mapping between item data and prefab that will be instantiated when this data is met")]
        [SerializeField] private List<ItemPrefab> itemPrefabsDictionary;
        
        /// <summary>
        /// Reference to the json file with all items information
        /// </summary>
        /// <seealso cref="TextAsset"/>
        [Space(10)]
        [Tooltip("Select a JSON file with all items information")][SerializeField] private TextAsset jsonItemsFile;

        /// <summary>
        /// Database of all items available for spawn
        /// </summary>
        /// <seealso cref="ItemsDB"/>
        private ItemsDB _itemsDB;

        #endregion
        
        #region Methods

        #region Unity Standard

        /// <summary>
        /// Initializes items database and item spawning methods/events
        /// </summary>
        private void Start()
        {
            // Subscribe to onItemDestroy event
            ItemDelegates.onItemDestroy += SpawnRandomItem;

            // Load all items from the JSON file - if there is an asset
            if (!jsonItemsFile)
            {
                Debug.LogError($"TextAsset is missing at {name}");
                return;
            }
            
            _itemsDB = JSONReader.ReadItemsFromJson(jsonItemsFile);

            SpawnRandomItem();
        }

        private void OnDestroy()
        {
            ItemDelegates.onItemDestroy -= SpawnRandomItem;
        }

        #endregion

        #region Item Spawn

        private void SpawnRandomItem()
        {
            var obj = _itemsDB.GetItemAt(Random.Range(0, _itemsDB.items.Count));
            
            foreach (var item in itemPrefabsDictionary)
            {
                if (item.color != obj.color || item.type != obj.itemType) continue;
                
                Vector3 pointOne = GetRandomPointBetweenVectors(
                    new Vector3(spawnArea.leftBottomCorner.x, 0f, spawnArea.leftBottomCorner.y),
                    new Vector3(spawnArea.leftTopCorner.x, 0f, spawnArea.leftTopCorner.y));

                Vector3 pointTwo = GetRandomPointBetweenVectors(
                    new Vector3(spawnArea.rightBottomCorner.x, 0f, spawnArea.rightBottomCorner.y),
                    new Vector3(spawnArea.rightTopCorner.x, 0f, spawnArea.rightTopCorner.y));

                Vector3 spawnPosition = GetRandomPointBetweenVectors(pointOne, pointTwo);

                // Increasing the height by 0.5f to not be stuck in the ground
                var newItem = Instantiate(item.prefab, new Vector3(spawnPosition.x, 0.5f, spawnPosition.z), Quaternion.identity);
                    
                // Setting data of an item to the instance
                newItem.GetComponent<ItemMonoObject>().SetData(obj);
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
