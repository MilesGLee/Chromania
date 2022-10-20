using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColoredColliderBehaviour : MonoBehaviour
{
    [SerializeField] private List<BoxCollider> _collidersRed;
    [SerializeField] private List<BoxCollider> _collidersBlue;
    [SerializeField] private List<BoxCollider> _collidersGreen;
    [SerializeField] private List<BoxCollider> _collidersWhite;
    [SerializeField] private ChamberBehaviour _chamberBehaviour;
    private bool _redTrigger;
    private bool _blueTrigger;
    private bool _greenTrigger;
    private bool _whiteTrigger;

    private void Start()
    {
        BoxCollider[] colliders = FindObjectsOfType<BoxCollider>();
        foreach (BoxCollider c in colliders) 
        {
            if(c.tag == "Red")
                _collidersRed.Add(c);
            if (c.tag == "Blue")
                _collidersBlue.Add(c);
            if (c.tag == "Green")
                _collidersGreen.Add(c);
            if (c.tag == "White")
                _collidersWhite.Add(c);
        }
    }

    private void Update()
    {
        //print(_chamberBehaviour.transform.localEulerAngles.y);
        //Red side
        if (_chamberBehaviour.Mode == 0 && !_redTrigger)
        {
            //print("RED SIDE");
            _redTrigger = true;
            _whiteTrigger = false;
            _blueTrigger = false;
            _greenTrigger = false;
            foreach (BoxCollider c in _collidersRed)
            {
                c.isTrigger = false;
            }
            foreach (BoxCollider c in _collidersBlue)
            {
                c.isTrigger = true;
            }
            foreach (BoxCollider c in _collidersGreen)
            {
                c.isTrigger = true;
            }
            foreach (BoxCollider c in _collidersWhite)
            {
                c.isTrigger = true;
            }
        }

        //White side
        if (_chamberBehaviour.Mode == 1 && !_whiteTrigger)
        {
            //print("White side");
            _redTrigger = false;
            _whiteTrigger = true;
            _blueTrigger = false;
            _greenTrigger = false;
            foreach (BoxCollider c in _collidersRed)
            {
                c.isTrigger = true;
            }
            foreach (BoxCollider c in _collidersBlue)
            {
                c.isTrigger = true;
            }
            foreach (BoxCollider c in _collidersGreen)
            {
                c.isTrigger = true;
            }
            foreach (BoxCollider c in _collidersWhite)
            {
                c.isTrigger = false;
            }
        }

        //Blue side
        if (_chamberBehaviour.Mode == 2 && !_blueTrigger)
        {
            //print("BLUE SIDE");
            _redTrigger = false;
            _whiteTrigger = false;
            _blueTrigger = true;
            _greenTrigger = false;
            foreach (BoxCollider c in _collidersRed)
            {
                c.isTrigger = true;
            }
            foreach (BoxCollider c in _collidersBlue)
            {
                c.isTrigger = false;
            }
            foreach (BoxCollider c in _collidersGreen)
            {
                c.isTrigger = true;
            }
            foreach (BoxCollider c in _collidersWhite)
            {
                c.isTrigger = true;
            }
        }

        //Green side
        if (_chamberBehaviour.Mode == 3 && !_greenTrigger)
        {
            //print("Green SIDE");
            _redTrigger = false;
            _whiteTrigger = false;
            _blueTrigger = false;
            _greenTrigger = true;
            foreach (BoxCollider c in _collidersRed)
            {
                c.isTrigger = true;
            }
            foreach (BoxCollider c in _collidersBlue)
            {
                c.isTrigger = true;
            }
            foreach (BoxCollider c in _collidersGreen)
            {
                c.isTrigger = false;
            }
            foreach (BoxCollider c in _collidersWhite)
            {
                c.isTrigger = true;
            }
        }

    }
}
