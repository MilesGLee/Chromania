using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChamberBehaviour : MonoBehaviour
{
    [SerializeField] private Vector3 _hipPosition;
    [SerializeField] private Vector3 _eyePosition;
    private bool _placement;
    private Quaternion _desiredRotation;
    private float _desiredAngle;
    private int _mode;

    public int Mode { get { return _mode; } }

    public bool Placement { get { return _placement; } }

    private void Awake()
    {
        _hipPosition = transform.localPosition;
        _desiredRotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
        _desiredAngle = 0.0f;
        _placement = false;
        _mode = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            _mode++;
            _desiredAngle += 90.0f;
            _desiredRotation = Quaternion.Euler(0.0f, _desiredAngle, 0.0f);
            if (_mode >= 4) 
            {
                _mode = 0;
            }
        }

        transform.localRotation = Quaternion.Lerp(transform.localRotation, _desiredRotation, 3.5f * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Mouse1)) 
        {
            _placement = true;
        }

        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            _placement = false;
        }

        if (_placement)
            transform.localPosition = Vector3.Lerp(transform.localPosition, _eyePosition, 5 * Time.deltaTime);
        if (!_placement)
            transform.localPosition = Vector3.Lerp(transform.localPosition, _hipPosition, 2 * Time.deltaTime);
    }
}
