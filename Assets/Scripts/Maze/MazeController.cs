using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeController : MonoBehaviour
{
    // Singleton
    private static MazeController _instance;
    public static MazeController Instance { get { return _instance; } }
    
    
    
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
    }

    // Start
    private void Start()
    {
        // Activate included aisles
        foreach (Tuple<int, int> edge in MazeInfo.Instance.IncludedEdges)
        {
            MazeInfo.Instance.EdgeToAisle[edge].SetActive(true);
        }
    }
}
