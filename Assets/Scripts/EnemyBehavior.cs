using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] private int _health;
    private NavMeshAgent _navAgent;
    private Transform _target;
    private WorldMaterialBehaviour _materialBehaviour;
    private bool _touching;
    private bool _timeCheck;

    private void Awake()
    {
        _navAgent = GetComponent<NavMeshAgent>();
        _target = FindObjectOfType<FPS_Movement>().transform;
        _materialBehaviour = FindObjectOfType<WorldMaterialBehaviour>();

        _health = 1;
    }

    private void Update()
    {
        _navAgent.SetDestination(_target.position);

        if (_health <= 0)
            Death();
    }

    public void TakeDamage(int damage) 
    {
        _health -= damage;
    }

    void Death() 
    {
        _materialBehaviour.RNGChangeMesh();
        Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        if (!_timeCheck)
        {
            _timeCheck = true;
            _touching = true;
            RoutineBehaviour.Instance.StartNewTimedAction(args => { DamagePlayer();  _timeCheck = false; }, TimedActionCountType.SCALEDTIME, 1.0f);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _touching = false;
    }

    void DamagePlayer() 
    {
        if (_touching) 
        {
            _target.GetComponent<PlayerHealthBehaviour>().TakeDamage();
            _target.GetComponent<PlayerHealthBehaviour>().CancelRegen();
        }
    }
}
