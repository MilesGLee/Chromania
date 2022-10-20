using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBehaviour : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Image _displayHealth;
    [SerializeField] private Color _goodColor;
    [SerializeField] private Color _goodishColor;
    [SerializeField] private Color _mediumColor;
    [SerializeField] private Color _badishColor;
    [SerializeField] private Color _badColor;

    private RoutineBehaviour.TimedAction _regenAction;
    public bool CanRegen;

    public int Health { get { return _health; } }

    private void Awake()
    {
        _health = 5;
        _regenAction = new RoutineBehaviour.TimedAction();
    }

    public void TakeDamage() 
    {
        _health--;
    }

    private void Update()
    {
        if (_health == 5)
            _displayHealth.color = _goodColor;
        if (_health == 4)
            _displayHealth.color = _goodishColor;
        if (_health == 3)
            _displayHealth.color = _mediumColor;
        if (_health == 2)
            _displayHealth.color = _badishColor;
        if (_health == 1)
            _displayHealth.color = _badColor;

        if (_health == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Application.LoadLevel("main_menu");
        }

        if (!_regenAction.IsActive && _health < 5 && CanRegen) 
        {
            _regenAction = RoutineBehaviour.Instance.StartNewTimedAction(args => { _health++; }, TimedActionCountType.SCALEDTIME, 1.0f);
        }
    }

    public void CancelRegen() 
    {
        CanRegen = false;
        RoutineBehaviour.Instance.StartNewTimedAction(args => CanRegen = true, TimedActionCountType.SCALEDTIME, 5.0f);
    }
}
