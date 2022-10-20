using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandDamageBehaviour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EnemyBehavior>()) 
        {
            other.GetComponent<EnemyBehavior>().TakeDamage(1);
        }
    }
}
