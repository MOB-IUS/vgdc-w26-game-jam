using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

// Singleton class for storing all the info about maze
// Including Graph, EdgeToAisles, IncludedEdges
// Each edge is represented as a Tuple<int, int> object
public class MazeInfo : MonoBehaviour
{
    // Singleton
    private static MazeInfo _instance;
    public static MazeInfo Instance { get { return _instance; } }
    
    // Const variables
    private const int ROOM_SIZE = 36;
    private const int EDGE_SIZE = 60;
    
    // Member variables
    public List<List<int>> Graph { get; set; }
    public Dictionary<Tuple<int, int>, GameObject> EdgeToAisle { get; set; }
    public List<Tuple<int, int>> IncludedEdges { get; set; }
    
    private Dictionary<Tuple<int, int>, float> _edgeLengths = new Dictionary<Tuple<int, int>, float>();
    private List<Tuple<int, int>> _sortedEdges = new List<Tuple<int, int>>();    // Sort edges with weight in ascending order
    private List<HashSet<int>> _clouds = new List<HashSet<int>>();               // Groups of rooms; Update only lead of rooms in _cloudLead
    private List<int> _cloudLead = new List<int>();                              // Smallest room number in the same group as room i does
    private List<int> _graphDirections = new List<int>() { -6, -1, 1, 6 };
    
    
    // Awake
    void Awake()
    {
        // Singleton
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        
        // Initialization
        _instance = this;
        Graph = new List<List<int>>();
        EdgeToAisle = new Dictionary<Tuple<int, int>, GameObject>();
        IncludedEdges = new List<Tuple<int, int>>();
        
        // Initalize Graph adjacency list
        for (int i = 0; i < 36; i++)
        {
            Graph.Add(new List<int>());
            for (int j = 0; j < 4; j++)
            {
                int nextIndex = i + _graphDirections[j];
                if (nextIndex >= 0 && nextIndex < 36)
                {
                    Graph[i].Add(nextIndex);
                }
                
                // Fix for right-most column
                if ((i + 1) % 6 == 0)
                {
                    Graph[i].Remove(i + 1);
                }
                
                // Fix for left-most column
                if (i % 6 == 0)
                {
                    Graph[i].Remove(i - 1);
                }
            }
        }
        
        // Initialize EdgeLengths with random edge length
        // and EdgeToAisle with aisles in the scene
        int index = 1;
        for (int i = 0; i < 35; i++)
        {
            foreach (int toIndex in Graph[i])
            {
                if (toIndex > i)
                {
                    _edgeLengths[Tuple.Create(i, toIndex)] = Random.Range(0f, 20f);
                    EdgeToAisle[Tuple.Create(i, toIndex)] = GameObject.Find("Aisle" + index);
                    index++;
                }
            }
        }
        
        // Sort edge by weights into _sortedEdges
        foreach (Tuple<int, int> edge in _edgeLengths.Keys)
        {
            // Bubble down to sort
            int i = _sortedEdges.Count; // Index of new edge
            _sortedEdges.Add(edge);
            while (i > 0 && (_edgeLengths[_sortedEdges[i]] < _edgeLengths[_sortedEdges[i - 1]]))
            {
                Tuple<int, int> temp = _sortedEdges[i - 1];
                _sortedEdges[i - 1] = _sortedEdges[i];
                _sortedEdges[i] = temp;
                i--;
            }
        }
        
        // Get included edges by finding MST
        // and store in IncludedEdges
        for (int i = 0; i < ROOM_SIZE; i++)         // Initialize _clouds and _cloudLead
        {
            // Initialize _clouds
            _clouds.Add(new HashSet<int>());
            _clouds[i].Add(i);
            
            // Initialize _cloudLead
            _cloudLead.Add(i);
        }

        for (int i = 0; i < EDGE_SIZE; i++)         // Get all edges included in max into IncludedEdges
        {
            int edgeFrom = _sortedEdges[i].Item1;
            int edgeTo = _sortedEdges[i].Item2;
            int cloud1 = (_cloudLead[edgeFrom] < _cloudLead[edgeTo]) ? _cloudLead[edgeFrom] : _cloudLead[edgeTo];
            int cloud2 = (_cloudLead[edgeFrom] >= _cloudLead[edgeTo]) ? _cloudLead[edgeFrom] : _cloudLead[edgeTo];
            
            if (cloud1 != cloud2)
            {   
                // Add edge into MSTs
                IncludedEdges.Add(_sortedEdges[i]);
                
                // Update _clouds and _cloudLead
                foreach (int roomIndex in _clouds[cloud2])
                {
                    _clouds[cloud1].Add(roomIndex);
                    _cloudLead[roomIndex] = cloud1;
                }
            }
        }
    }
}






















