using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCanva : MonoBehaviour
{
    public static ControlCanva Instance { get; private set; } 

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
