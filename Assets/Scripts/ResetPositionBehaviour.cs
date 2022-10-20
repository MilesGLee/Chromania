using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPositionBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player") 
        {
            other.transform.position += new Vector3(0.0f, 10.0f, 0.0f);
        }
    }
}
