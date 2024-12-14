using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInactiveDetector : MonoBehaviour
{
    [SerializeField] private GameObject gameOverPanel;
    private GameObject player;
    private float inactivityTimer = 0f;
    private bool playerActive = true;

    // Tiempo de inactividad para considerar Game Over (en segundos)
    private float inactivityThreshold = 2f;

    private void OnEnable()
    {
        
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
       
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        
        FindPlayerOnSceneLoad();
    }

    private void Update()
    {
        if (player != null && player.activeInHierarchy)
        {
            inactivityTimer = 0f;
            playerActive = true;
        }
        else
        {
            inactivityTimer += Time.deltaTime;
            playerActive = false;
        }

        if (inactivityTimer >= inactivityThreshold)
        {
            TriggerGameOver();
        }
    }

    private void FindPlayerOnSceneLoad()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (player == null)
        {
            Debug.LogWarning("No se encontró al jugador en la escena.");
        }
    }

    private void TriggerGameOver()
    {
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f; 
        }
    }
}

