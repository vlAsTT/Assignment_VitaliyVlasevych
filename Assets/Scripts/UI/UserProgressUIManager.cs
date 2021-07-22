using TMPro;
using UnityEngine;

namespace UI
{
    /// <summary>
    /// UI Manager that handles Score, Streak & Game Over functionality
    /// </summary>
    public class UserProgressUIManager : MonoBehaviour
    {
        #region Variables

        /// <summary>
        /// Reference to the score text object
        /// </summary>
        /// <seealso cref="TextMeshProUGUI"/>
        [Header("Gameplay Elements")] [Tooltip("Reference to the score text object that displays the actual score")]
        [SerializeField] private TextMeshProUGUI scoreField;

        /// <summary>
        /// Reference to the streak text object
        /// </summary>
        [Tooltip("Reference to the streak text object that displays the actual streak")]
        [SerializeField] private TextMeshProUGUI streakField;

        /// <summary>
        /// Reference to the Game Over Menu Object
        /// </summary>
        [Header("In-Game Menu Elements")] 
        [Tooltip("Reference to the Game Over Menu Object")] [SerializeField] private GameObject gameOverScreen;
        
        /// <summary>
        /// Reference to the Game Over score text object
        /// </summary>
        [Tooltip("Reference to the Game Over score text object that displays final score")]
        [SerializeField] private TextMeshProUGUI gameOverScoreField;

        #endregion

        #region Methods

        /// <summary>
        /// Initializes UI score & streak elements
        /// </summary>
        private void Start()
        {
            // UI Objects references validity checks
            if (!scoreField || !streakField || !gameOverScreen || !gameOverScoreField)
            {
                Debug.LogError($"UI Reference(s) is/are missing at {name}");
                return;
            }
            
            // Hides Game Over Screen
            gameOverScreen.SetActive(false);
            
            // Initializes Score & Streak UI values
            UpdateScore(0);
            UpdateStreak(1);
        }

        #region Update / Show Values

        /// <summary>
        /// Sets new score at UI
        /// </summary>
        /// <param name="score">New Score</param>
        public void UpdateScore(int score)
        {
            scoreField.text = score.ToString();
        }

        /// <summary>
        /// Sets new streak at UI
        /// </summary>
        /// <param name="streak">New Streak</param>
        public void UpdateStreak(int streak)
        {
            streakField.text = streak.ToString();
        }

        /// <summary>
        /// Displays Game Over Screen with Final Score
        /// </summary>
        /// <param name="score">Final Score</param>
        public void ShowGameOverScreen(int score)
        {
            gameOverScreen.SetActive(true);
            gameOverScoreField.text = "Your Score:\n" + score;
        }

        #endregion

        #endregion
    }
}
