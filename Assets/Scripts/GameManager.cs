using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerManager playerManager;
    public UIManager uiManager;
    public Config config;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Application.targetFrameRate = 144;
            config = new Config() { camSensitivity = 10 };
            DontDestroyOnLoad(gameObject);
        }
        else Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
