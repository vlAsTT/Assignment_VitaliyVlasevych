using System;
using Core;
using Items.Core;
using Snake.Movement;
using UnityEngine;

namespace Snake.Gameplay
{
    public class TailIncreaser : MonoBehaviour
    {
        public MovementController _movementController;

        private void Start()
        {
            _movementController = GetComponentInParent<MovementController>();
        }

        #region Collision

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag.Equals("Item"))
            {
                // Call an event
                ItemDelegates.OnItemDestroy();
            
                // Call GameManager to increase score & streak
                var data = other.GetComponent<ItemMonoObject>().GetData();
                GameManager.Instance.AddScore(data.color, data.points);
                
                // Destroy item object
                Destroy(other.gameObject);
            }
            else if (other.tag.Equals("Snake") || other.tag.Equals("Edge"))
            {
                // Call Game Over method on GameManager that stops game and calls UI manager
                GameManager.Instance.GameOver();
            }
            
        }

        #endregion
    }
}
