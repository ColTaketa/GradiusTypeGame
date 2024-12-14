using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStarter : MonoBehaviour
{

    private bool isGamePaused = false;
    public static SceneStarter Instance { get; private set; } 


    public void LoadSceneByName(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
         PlayerPoints.Instance.points = 0;
        PlayerLife playerLife = FindObjectOfType<PlayerLife>();
        if (playerLife != null)
        {
            playerLife.ResetLife();
        }
    }

      public void RestartGameFromStart(string startSceneName)
    {
        SceneManager.LoadScene(startSceneName);
        ResetGameState();
        Time.timeScale = 1f;
    }

        private void ResetGameState()
    {
        PlayerPoints.Instance.points = 0; 
        PlayerLife playerLife = FindObjectOfType<PlayerLife>();
        if (playerLife != null)
        {
            playerLife.ResetLife();
        }
    }


    public void TogglePauseGame()
    {
        if (isGamePaused)
        {
            Time.timeScale = 1f; 
            isGamePaused = false;
        }
        else
        {
            Time.timeScale = 0f; 
            isGamePaused = true;
        }
    }

    public void ExitGame()
    {
        Debug.Log("Exiting the game..."); // Mensaje para depuración
        Application.Quit();
    }
}
