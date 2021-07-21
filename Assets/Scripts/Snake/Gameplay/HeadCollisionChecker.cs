using Core;
using Items.Core;
using UnityEngine;

namespace Snake.Gameplay
{
    /// <summary>
    /// Handles Collision of Snake's Head with different in-game objects
    /// </summary>
    public class HeadCollisionChecker : MonoBehaviour
    {
        /// <summary>
        /// Called when snake's head collides with any other in-game object
        /// </summary>
        /// <param name="other">Collider of hit object</param>
        private void OnTriggerEnter(Collider other)
        {
            // Check for a hit object tag
            if (other.tag.Equals("Item")) // Destroy item & Add Score for it
            {
                // Call an event
                ItemDelegates.OnItemDestroy();
            
                // Call GameManager to increase score & streak
                var data = other.GetComponent<ItemMonoObject>().GetData();
                GameManager.Instance.AddScore(data.color, data.points);
                
                // Destroy item object
                Destroy(other.gameObject);
            }
            else if (other.tag.Equals("Snake") || other.tag.Equals("Edge")) // Game Over
            {
                // Call Game Over method on GameManager that stops game and calls UI manager
                GameManager.Instance.GameOver();
            }
            
        }
    }
}
