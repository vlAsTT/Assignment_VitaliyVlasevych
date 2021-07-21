using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    /// <summary>
    /// 
    /// </summary>
    public class MainMenuLoader : MonoBehaviour
    {
        [SerializeField] private GameObject menu;
        [SerializeField] private GameObject loadingScreen;
        [SerializeField] private Image loadingProgressBar;

        [SerializeField] private TextMeshProUGUI topScoreField;

        private List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();
        
        public void StartGame()
        {
            HideMenu();
            ShowLoadingScreen();

            SceneManager.LoadSceneAsync("_Scenes/Game/Game");
            SceneManager.LoadSceneAsync("Core", LoadSceneMode.Additive);

            StartCoroutine(StartLoadingScreen());
        }

        public void ShowTopScore()
        {
            topScoreField.text = PlayerPrefs.GetInt("TopScore", 0).ToString();
        }

        public void Exit()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#endif
            Application.Quit(1);
        }

        #region Utility Methods

        private void HideMenu()
        {
            menu.SetActive(false);
        }

        private void ShowLoadingScreen()
        {
            loadingScreen.SetActive(true);
        }

        IEnumerator StartLoadingScreen()
        {
            var totalProgress = 0f;

            foreach (var scene in scenesToLoad)
            {
                while (!scene.isDone)
                {
                    totalProgress += scene.progress;
                    loadingProgressBar.fillAmount = totalProgress / scenesToLoad.Count;
                    yield return null;
                }
            }
        }

        #endregion
    }
}
