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
        // and update dungeon rooms' mid-walls accordingly
        foreach (Tuple<int, int> edge in MazeInfo.Instance.IncludedEdges)
        {
            // Activate aisle
            MazeInfo.Instance.EdgeToAisle[edge].SetActive(true);
            
            // Change room mid-wall
            int roomFrom = edge.Item1;
            int roomTo = edge.Item2;
            GameObject.Find("Room_" + (roomFrom + 1)).GetComponent<MazeRoom>().ChangeWall(roomFrom, roomTo);
            GameObject.Find("Room_" + (roomTo + 1)).GetComponent<MazeRoom>().ChangeWall(roomTo, roomFrom);
        }
    }
}
