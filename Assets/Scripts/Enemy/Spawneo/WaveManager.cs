using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class WaveManager : MonoBehaviour
{
    public List<MonoBehaviour> spawners; 
    float waveInterval = 10f; 
    [SerializeField] float timeToOtherLevel;
     [SerializeField] TextMeshProUGUI textCounter;
     private bool timerRunning = true;


    private IEnumerator StartWaveRoutine()
    {
        foreach (MonoBehaviour spawner in spawners)
        {
            ISpawner spawnerScript = spawner as ISpawner;

            if (spawnerScript == null) continue;

            
            yield return StartCoroutine(spawnerScript.StartWave(2)); 

           
            spawner.gameObject.SetActive(false);
        }

        
        if (AreAllSpawnersDeactivated())
        {
            StartCoroutine(EndLevel());
        }
        else
        {
            
            yield return new WaitForSeconds(waveInterval);
            StartCoroutine(StartWaveRoutine());
        }
    }

    private bool AreAllSpawnersDeactivated()
    {
        foreach (var spawner in spawners)
        {
            if (spawner.gameObject.activeSelf)
            {
                return false; 
            }
        }
        return true; 
    }

    private void Start()
    {
        timeToOtherLevel = 20;

        StartCoroutine(StartCountdown());
    }
    private void Update() 
    {

    }

    private IEnumerator StartCountdown()
    {
        yield return new WaitForSeconds(5f); 
        StartCoroutine(StartWaveRoutine());
    }

    private IEnumerator EndLevel()
    {
        StartCoroutine(UpdateCountdown()); 
        yield return new WaitForSeconds(timeToOtherLevel); 
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); 
    }

    private IEnumerator UpdateCountdown()
    {
        float remainingTime = timeToOtherLevel;

        while (remainingTime > 0)
        {
            textCounter.text = "Be prepared: " + Mathf.Ceil(remainingTime).ToString(); 
            yield return new WaitForSeconds(1f); 
            remainingTime--; 
        }

        textCounter.text = "Be prepared: 0";
    }
}
