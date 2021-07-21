using Items.Core;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    /// <summary>
    /// Manager that handles game logic and is responsible for the UI update calls
    /// Implemented via Singleton pattern
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        #region Variables

        #region Instance

        /// <summary>
        /// Instance of GameManager 
        /// </summary>
        private static GameManager _instance;
        
        /// <summary>
        /// Getter of GameManager Instance
        /// </summary>
        /// <seealso cref="_instance"/>
        public static GameManager Instance => _instance;

        #endregion

        #region Game Logic

        /// <summary>
        /// Current Score in the session
        /// </summary>
        private int _currentScore = 0;

        /// <summary>
        /// Current Streak in the session
        /// </summary>
        private int _currentStreak = 1;

        /// <summary>
        /// Current Color in the session
        /// </summary>
        private ItemColor _currentColor = ItemColor.Default;

        #endregion

        #region References

        /// <summary>
        /// Reference to the In-Game HUD with Streak & Score variables
        /// </summary>
        [Header("Managers References")] [Tooltip("Reference to the In-Game HUD with Streak & Score variables")]
        [SerializeField] private UserProgressUIManager uiManager;

        #endregion
        
        #endregion

        #region Methods

        #region Unity Standard

        /// <summary>
        /// Checks for the existing instance of this class and if there is one - destroys it
        /// Otherwise - sets this one to be the only instance
        /// </summary>
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                _instance = this;
            }
        }

        #endregion

        #region Game Logic

        /// <summary>
        /// Adds certain amount of points to the current score and increments or resets streak depending on the item color
        /// </summary>
        /// <param name="color">Food's item eaten color</param>
        /// <param name="points">Amount of points obtained for this food item</param>
        /// <seealso cref="Item"/>
        public void AddScore(ItemColor color, int points)
        {
            // Streak Check
            _currentStreak = _currentColor.Equals(color) ? _currentStreak + 1 : 1;
            _currentColor = color;
            
            // Adding points
            _currentScore += points * _currentStreak;
            
            // Check if a UI Manager Reference is valid
            if (!uiManager)
            {
                Debug.LogError($"UI Manager is missing at {name}");
                return;
            }
            
            // Update UI
            uiManager.UpdateScore(_currentScore);
            uiManager.UpdateStreak(_currentStreak);
        }

        #endregion

        #region Game Over

        /// <summary>
        /// Does appropriate checks & calls when game over condition is met
        /// </summary>
        /// <seealso cref="PlayerPrefs"/>
        public void GameOver()
        {
            // Resetting all values is an important part if restart from the same scene will be added in the future
            // For now - it's redundant and so commented
            // _currentScore = 0;
            // _currentStreak = 1;
            // _currentColor = ItemColor.Default;

            // Top Score Obtaining from PlayerPrefs
            var topScore = PlayerPrefs.GetInt("TopScore", 0);

            // If current one is higher - set new top score
            if (_currentScore > topScore)
            {
                PlayerPrefs.SetInt("TopScore", _currentScore);
            }
            
            // Freezes time, so game isn't continued
            Time.timeScale = 0;
            
            // Check if a UI Manager Reference is valid
            if (!uiManager)
            {
                Debug.LogError($"UI Manager is missing at {name}");
                return;
            }
            
            // Shows UI Game Over Screen
            uiManager.ShowGameOverScreen(_currentScore);
        }

        /// <summary>
        /// Loads Main Menu Scene and unfreezes the game
        /// </summary>
        /// <seealso cref="SceneManager"/>
        public void ProceedToMainMenu()
        {
            // Unfreezes time, so next time game continues fine
            Time.timeScale = 1;
            
            // Loads Main Menu Scene
            SceneManager.LoadSceneAsync("_Scenes/Menu/MainMenu");
        }

        #endregion

        #endregion
    }
}
