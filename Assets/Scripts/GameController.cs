using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Singleton
    private static GameController _instance;
    public static GameController Instance { get { return _instance; } }
    
    // Member variables
    public int CurrScore { get; set; }
    public int BestScore { get; set; }
    public float TimeLeft { get; set; }
    public float MaxTime { get; set; }
    public float MapTimeLeft { get; set; }
    public float MapMaxTime { get; set; }
    public float PotionTimeLeft { get; set; }
    public float MaxPotionTime { get; set; }

    [SerializeField] private GameObject _potionPrefab;
    private bool _isInGame = false;
    private bool _isInMap = false;
    private GameObject _potion = null;
    
    
    
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
        TimeLeft = 0f;
        MaxTime = 180f;
        MapTimeLeft = 0f;
        MapMaxTime = 10f;
        PotionTimeLeft = 0f;
        MaxPotionTime = 20f;
        DontDestroyOnLoad(gameObject);
    }
    
    // Update
    private void Update()
    {
        if (_isInGame)
        {
            if (_potion == null)
            {
                GenerateNewPotion();
            }
            
            TimeLeft -= Time.deltaTime;
            if (TimeLeft <= 0f)
            {
                this.EndGame();
            }
        }

        if (_isInMap)
        {
            MapTimeLeft -= Time.deltaTime;
            if (MapTimeLeft <= 0f)
            {
                _isInMap = false;
                CameraController.Instance.ChangeToPlayerCamera();
                PotionTimeLeft = MaxPotionTime;
            }
        }

        if (!_isInMap && _potion != null)
        {
            PotionTimeLeft -= Time.deltaTime;
            if (PotionTimeLeft <= 0f)
            {
                // Open map
                MapTimeLeft = MapMaxTime;
                CameraController.Instance.ChangeToMapCamera();
                _isInMap = true;
            }
        }
    }

    // Game starts
    public void StartGame()
    {
        CurrScore = 0;
        TimeLeft = MaxTime;
        _isInGame = true;
        
        // Change Scene
        SceneManager.LoadScene(1);
    }
    
    // Game ends
    public void EndGame()
    {
        // Update best score
        if (CurrScore > BestScore)
        {
            BestScore = CurrScore;
        }

        _isInGame = false;
        _isInMap = false;
        
        // Change Scene
        SceneManager.LoadScene(0);
    }
    
    // Generate a new potion in the dungeon
    public void GenerateNewPotion()
    {
        // Generate potion in map
        int roomNumber = (int)(UnityEngine.Random.Range(0f, 35.5f));
        _potion = Instantiate(_potionPrefab, GameObject.Find("Room_" + (roomNumber + 1).ToString()).transform);
        
        // Open map
        MapTimeLeft = MapMaxTime;
        CameraController.Instance.ChangeToMapCamera();
        _isInMap = true;
    }
}
