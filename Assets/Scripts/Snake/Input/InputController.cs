using Snake.Movement;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Snake.Input
{
    /// <summary>
    /// Handles all Player's Input
    /// </summary>
    [RequireComponent(typeof(MovementController))]
    public class InputController : MonoBehaviour
    {
        #region Variables

        /// <summary>
        /// Reference to the Movement Controller
        /// </summary>
        private MovementController _movementController;

        #endregion

        /// <summary>
        /// Initializes all references to the components
        /// </summary>
        private void Start()
        {
            _movementController = GetComponent<MovementController>();
        }

        /// <summary>
        /// Handles player's movement input & sends it to the movement controller
        /// </summary>
        /// <param name="ctx">Player's Input Data</param>
        public void OnPlayerMovementInput(InputAction.CallbackContext ctx)
        {
            if (!ctx.started) return;

            var axis = ctx.ReadValue<Vector2>();
            _movementController.UpdateMovementDirection(axis);
        }
    }
}
