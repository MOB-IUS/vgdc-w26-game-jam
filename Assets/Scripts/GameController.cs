using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Singleton
    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }
    
    // Member variables
    public int CurrScore { get; set; }
    public int BestScore { get; set; }
    public float CurrTime { get; set; }
    public float MaxTime { get; set; }

    private bool _isInGame = false;
    
    
    
    // Awake
    private void Awake()
    {
        // Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        
        // Initialization
        _instance = this;
        BestScore = 0;
        CurrTime = 0f;
        MaxTime = 210f;
        DontDestroyOnLoad(gameObject);
    }
    
    // Update
    private void Update()
    {
        if (_isInGame)
        {
            CurrTime += Time.deltaTime;
            if (CurrTime >= MaxTime)
            {
                this.EndGame();
            }
        }
    }

    // Game starts
    public void StartGame()
    {
        CurrScore = 0;
        CurrTime = 0f;
        _isInGame = true;
        Debug.Log("StartGame");
    }
    
    // Game ends
    public void EndGame()
    {
        // Update best score
        if (CurrScore > BestScore)
        {
            BestScore = CurrScore;
        }
        Debug.Log("EndGame");
    }
}
