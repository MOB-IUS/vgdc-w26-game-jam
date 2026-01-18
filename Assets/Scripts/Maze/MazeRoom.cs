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
    public void ChangeWall(int thisRoom, int targetRoom)
    {
        // Determine index
        int direction = targetRoom - thisRoom;
        int index = -1;
        if (direction == -6)
        {
            index = 0;
        }
        else if (direction == 1)
        {
            index = 1;
        }
        else if (direction == 6)
        {
            index = 2;
        }
        else if (direction == -1)
        {
            index = 3;
        }
        else
        {
            Debug.LogError("Input direction invalid");
        }
        
        // Change wall
        MidWalls[index].SetActive(false);
        ArcWalls[index].SetActive(true);
    }
}
