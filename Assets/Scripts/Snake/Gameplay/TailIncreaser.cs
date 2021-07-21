using System;
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
            // Call an event
            ItemDelegates.OnItemDestroy();
            
            // Destroy item object
            Destroy(other.gameObject);
        }

        #endregion
    }
}
