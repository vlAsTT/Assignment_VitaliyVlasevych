using System;
using TMPro;
using UnityEngine;

namespace UI
{
    public class UserProgressUIManager : MonoBehaviour
    {
        #region Variables

        [Header("Gameplay Elements")] 
        [SerializeField] private TextMeshProUGUI scoreField;

        [SerializeField] private TextMeshProUGUI streakField;

        [Header("In-Game Menu Elements")] 
        [SerializeField] private GameObject gameOverScreen;
        [SerializeField] private TextMeshProUGUI gameOverScoreField;
        
        #endregion

        #region Methods

        private void Start()
        {
            gameOverScreen.SetActive(false);
            
            UpdateScore(0);
            UpdateStreak(1);
        }

        public void UpdateScore(int score)
        {
            scoreField.text = score.ToString();
        }

        public void UpdateStreak(int streak)
        {
            streakField.text = streak.ToString();
        }

        public void ShowGameOverScreen(int score)
        {
            gameOverScreen.SetActive(true);
            gameOverScoreField.text = "Your Score:\n" + score;
        }

        #endregion
    }
}
