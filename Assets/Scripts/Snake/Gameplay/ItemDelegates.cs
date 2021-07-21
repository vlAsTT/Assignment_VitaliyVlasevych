using UnityEngine;

namespace Snake.Gameplay
{
    /// <summary>
    /// Delegates that are related to items
    /// </summary>
    public class ItemDelegates : MonoBehaviour
    {
        /// <summary>
        /// Delegate of an Item Event
        /// </summary>
        public delegate void ItemEvent();

        /// <summary>
        /// Event that is being called when item is getting destroyed
        /// </summary>
        public static event ItemEvent onItemDestroy;

        /// <summary>
        /// Method that calls event for all subscribers to onItemDestroy event
        /// </summary>
        public static void OnItemDestroy()
        {
            onItemDestroy?.Invoke();
        }
    }
}
