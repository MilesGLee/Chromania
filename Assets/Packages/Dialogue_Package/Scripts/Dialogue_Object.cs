using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Dialogue_Object : MonoBehaviour
{
    [SerializeField] private string _name;

    public string Name { get { return _name; } }

    [SerializeField] private List<Dialogue_Piece> m_piecesOfDialogue;
    public List<Dialogue_Piece> PiecesOfDialogue { get { return m_piecesOfDialogue; } }

    [SerializeField] private float _indexAmount;

    [SerializeField] private UnityEvent _completeEvent;

    public string CurrentDialogue;
    public int CurrentIndex;

    private void Awake()
    {
        
    }

    private void Update()
    {
        if (CurrentIndex >= _indexAmount)
            _completeEvent.Invoke();
    }
}
