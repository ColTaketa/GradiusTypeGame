using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPoints : MonoBehaviour
{
    public int points;
    [SerializeField] TextMeshProUGUI pointsText;

    public static PlayerPoints Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    private void Start()
    {
        AssignPointsText();
   
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
        public void ResetPoints()
    {
        points = 0; 
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Update()
    {
        if (pointsText != null)
        {
            pointsText.text = "Points: " + points;
        }
    }

    private void AssignPointsText()
    {
        GameObject textObject = GameObject.FindGameObjectWithTag("PointsT");
        if (textObject != null)
        {
            pointsText = textObject.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogWarning("No se encontró el texto de puntos en la escena.");
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignPointsText();
    }
}

