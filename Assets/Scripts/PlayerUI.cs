using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    // Member variables
    [SerializeField] private TMP_Text _timeText;
    [SerializeField] private TMP_Text _potionTimeText;
    
    
    
    // Update
    void Update()
    {
        _timeText.text = ((int)(GameController.Instance.TimeLeft)).ToString();
        _potionTimeText.text = ((int)(GameController.Instance.PotionTimeLeft)).ToString();
    }
}
