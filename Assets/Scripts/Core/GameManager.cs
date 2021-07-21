using System;
using Items.Core;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    public class GameManager : MonoBehaviour
    {
        private static GameManager _instance;

        private int _currentScore = 0;
        private int _currentStreak = 1;
        private ItemColor _currentColor = ItemColor.Default;
        
        [SerializeField] private UserProgressUIManager uiManager;
        
        public static GameManager Instance => _instance;

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

        public void AddScore(ItemColor color, int points)
        {
            // Streak Check
            _currentStreak = _currentColor.Equals(color) ? _currentStreak + 1 : 1;
            _currentColor = color;
            
            // Adding points
            _currentScore += points * _currentStreak;
            
            // Update UI
            uiManager.UpdateScore(_currentScore);
            uiManager.UpdateStreak(_currentStreak);
        }

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
            
            Time.timeScale = 0;
            uiManager.ShowGameOverScreen(_currentScore);
        }

        public void ProceedToMainMenu()
        {
            Time.timeScale = 1;
            SceneManager.LoadSceneAsync("_Scenes/Menu/MainMenu");
        }
    }
}
