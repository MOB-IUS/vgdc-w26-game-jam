using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    // Update
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(0f, 0f, 
            PlayerLocater.Instance.GetPlayerTransform().gameObject.GetComponent<PlayerController>().GetXOrientation() - 45f);
    }
}
