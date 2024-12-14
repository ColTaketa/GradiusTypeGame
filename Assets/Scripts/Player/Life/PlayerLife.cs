using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    [SerializeField] int phealth;
    [SerializeField] int currentHealth;
    [SerializeField] int plives;
    [SerializeField] TextMeshProUGUI lifeText, healthText;
    [SerializeField] LayerMask enemyBulletLayer;
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] LayerMask bossBeam;
    [SerializeField] LayerMask powerUpLayer;

    [SerializeField] SpriteRenderer playerRenderer; 
    [SerializeField] Color defaultColor = Color.green;
    [SerializeField] Color powerUpColor = Color.white;
    

    public bool defenseActivated = false;

    private void Awake()
    {
        
        GameObject[] existingObjects = GameObject.FindGameObjectsWithTag("Player");
        if (existingObjects.Length > 1)
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
    }
    


    private void Start()
    {
        plives = 2;
        currentHealth = phealth;
        AssignUITextReferences();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        
    }

    public void ResetLife()
    {
        plives = 2;
        phealth = 100;
        currentHealth = phealth;
        defenseActivated = false;
        UpdatePlayerColor(defaultColor);
    }

    private void Update()
        {
            healthText.text = "Current health: " + currentHealth;
            lifeText.text = "Lives: " + plives;
            if (currentHealth <= 0)
            {
                plives--;
                if (plives > 0)
                {
                    currentHealth = phealth;
                }
                else
                {
                    plives = 0;
                    gameObject.SetActive(false);
                }
            }
        }


    private IEnumerator DisableDefenseAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        defenseActivated = false;
        UpdatePlayerColor(defaultColor);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        int otherLayer = other.gameObject.layer;

        if (powerUpLayer == (powerUpLayer | (1 << otherLayer)))
        {
            defenseActivated = true;
            UpdatePlayerColor(powerUpColor); 
            StartCoroutine(DisableDefenseAfterDelay(2f));
            other.gameObject.SetActive(false);
        }

        if (defenseActivated) return;

        if (enemyBulletLayer == (enemyBulletLayer | (1 << otherLayer)))
        {
            currentHealth -= 15;
            other.gameObject.SetActive(false);
        }
        else if (enemyLayer == (enemyLayer | (1 << otherLayer)))
        {
            currentHealth -= 20;
            other.gameObject.SetActive(false);
        }
        else if (bossBeam == (bossBeam | (1 << otherLayer)))
        {
            currentHealth -= 35;
        }
    }

    private void UpdatePlayerColor(Color color)
    {
        if (playerRenderer != null)
        {
            playerRenderer.color = color;
        }
    }

    private void AssignUITextReferences()
    {
        GameObject lifeTextObject = GameObject.FindGameObjectWithTag("lifeT");
        if (lifeTextObject != null)
        {
            lifeText = lifeTextObject.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogWarning("No se encontró el texto de vida ('lifeT') en la escena.");
        }

        GameObject healthTextObject = GameObject.FindGameObjectWithTag("HealthT");
        if (healthTextObject != null)
        {
            healthText = healthTextObject.GetComponent<TextMeshProUGUI>();
        }
        else
        {
            Debug.LogWarning("No se encontró el texto de salud ('HealthT') en la escena.");
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AssignUITextReferences();
    }
}
