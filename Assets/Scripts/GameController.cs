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
        DontDestroyOnLoad(gameObject);
    }
    
    // Game starts
    public void StartGame()
    {
        CurrScore = 0;
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
