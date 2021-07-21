using UnityEngine;

namespace Snake.Gameplay
{
    /// <summary>
    /// 
    /// </summary>
    public class ItemDelegates : MonoBehaviour
    {
        public delegate void ItemEvent();

        public static event ItemEvent onItemDestroy;

        public static void OnItemDestroy()
        {
            onItemDestroy?.Invoke();
        }
    }
}
