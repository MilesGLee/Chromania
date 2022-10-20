using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue_Manager : MonoBehaviour
{
    [SerializeField] private Text _displayText;
    [SerializeField] private Text _nameText;
    [SerializeField] private Text _nextText;
    [SerializeField] private GameObject _dialogueObject;
    public Dialogue_Object CurrentDialogue;
    private bool _writingText;
    private List<Dialogue_Piece> _dialogueList = new List<Dialogue_Piece>();

    private void Awake()
    {
        _nextText.enabled = false;
        _dialogueObject.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && CurrentDialogue != null) 
        {
            TalkToDialogue();
        }
        if (_dialogueObject.active && CurrentDialogue == null)
            _dialogueObject.SetActive(false);
    }

    public void SetCurrentDialogue(Dialogue_Object dialogue) 
    {
        if (dialogue != null)
        {
            CurrentDialogue = dialogue;
            _nameText.text = CurrentDialogue.Name;
            FillDialogueList();
            _dialogueObject.SetActive(true);
        }
        if (dialogue == null)
        {
            CurrentDialogue = null;
        }
    }

    void FillDialogueList() 
    {
        _dialogueList.Clear();
        int index = CurrentDialogue.CurrentIndex;
        foreach (Dialogue_Piece d in CurrentDialogue.PiecesOfDialogue)
        {
            if (d.Index == index)
            {
                _dialogueList.Add(d);
            }
        }
    }

    public void TalkToDialogue() 
    {
        if (!_writingText) 
        {
            StartCoroutine(WriteText());
        }
    }

    IEnumerator WriteText() 
    {
        _nextText.enabled = false;
        _writingText = true;
        _displayText.text = "";
        foreach (Dialogue_Piece d in _dialogueList)
        {
            string currentText = d.Text;
            float duration = (d.Duration / currentText.Length);
            yield return new WaitForSeconds(d.Delay);
            for (int i = 0; i < currentText.Length - 1; i++)
            {
                yield return new WaitForSeconds(duration);
                _displayText.text = _displayText.text + d.Text[i];
            }
        }
        _writingText = false;
        _nextText.enabled = true;
        CurrentDialogue.CurrentIndex++;
        FillDialogueList();
    }
}
