using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StartRoomController : MonoBehaviour
{
    // Member variables
    [SerializeField] private TMP_Text _bestScoreText;
    
    
    
    // Start
    private void Start()
    {
        _bestScoreText.text = GameController.Instance.BestScore.ToString();
    }
}
