using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatBehaviour : MonoBehaviour
{
    [SerializeField] private Animator _armAnimator;
    private bool _punchCD;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !_punchCD) 
        {
            _punchCD = true;
            _armAnimator.SetTrigger("Punch");
            RoutineBehaviour.Instance.StartNewTimedAction(args => _punchCD = false, TimedActionCountType.SCALEDTIME, 0.45f);
        }
    }
}
