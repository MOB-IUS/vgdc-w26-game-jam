using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowardsPlayer : MonoBehaviour
{
    // Rotate toward the player
    void Update()
    {
        transform.LookAt(PlayerLocater.Instance.GetPlayerTransform());
        transform.Rotate(0, 180, 0);
    }
}
