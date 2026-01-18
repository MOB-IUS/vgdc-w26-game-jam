using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRoom : MonoBehaviour
{
    // Member variables
    // Walls with order of North, East, South, West
    [SerializeField] private GameObject[] MidWalls;
    [SerializeField] private GameObject[] ArcWalls;
    
    // Change MidWall to ArcWall
    // direction must be one of "North", "East", "South", "West"
    public void ChangeWall(string direction)
    {
        // Determine index
        int index;
        if (direction == "North")
        {
            index = 0;
        }
        else if (direction == "East")
        {
            index = 1;
        }
        else if (direction == "South")
        {
            index = 2;
        }
        else if (direction == "West")
        {
            index = 3;
        }
        else
        {
            index = -1;
            Debug.LogError("Input direction invalid");
        }
        
        // Change wall
        MidWalls[index].SetActive(false);
        ArcWalls[index].SetActive(true);
    }
}
