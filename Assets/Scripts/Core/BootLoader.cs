using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Core
{
    
    public class BootLoader : MonoBehaviour
    {
        /// <summary>
        /// Loads Menu & Core scenes
        /// Called when the application is starting
        /// </summary>
        private void Start()
        {
            SceneManager.LoadSceneAsync("_Scenes/Menu/MainMenu");
            
            // DontDestroyOnLoad(gameObject);
        }
    }
}
