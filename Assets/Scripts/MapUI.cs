using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapUI : MonoBehaviour
{
    // Member variables
    [SerializeField] private TMP_Text _gameTimeText;
    [SerializeField] private TMP_Text _mapTimeText;
    
    
    
    // Update
    void Update()
    {
        _gameTimeText.text = ((int)(GameController.Instance.TimeLeft)).ToString();
        _mapTimeText.text = ((int)(GameController.Instance.MapTimeLeft)).ToString();
    }
}
