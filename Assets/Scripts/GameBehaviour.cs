using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GameBehaviour : MonoBehaviour
{
    [SerializeField] private FPS_Movement _playerMovement;
    [SerializeField] private CombatBehaviour _combatBehaviour;
    [SerializeField] private ChamberBehaviour _chamberBehaviour;
    [SerializeField] private Dialogue_Manager _dialogueManager;

    [SerializeField] private GameObject _hasred;
    [SerializeField] private GameObject _chamber;
    [SerializeField] private GameObject _enemy;

    private RoutineBehaviour.TimedAction _spawnAction;

    private bool _spawnTime, _skipCheck;

    private void Start()
    {
        _playerMovement.enabled = false;
        _combatBehaviour.enabled = false;
        _chamberBehaviour.enabled = false;

        _hasred.SetActive(true);
        _chamber.SetActive(false);

        //_dialogueManager.CurrentDialogue = _hasred.GetComponent<Dialogue_Object>();
        _dialogueManager.SetCurrentDialogue(_hasred.GetComponent<Dialogue_Object>());

        _dialogueManager.TalkToDialogue();
        _dialogueManager.TalkToDialogue();

        _spawnTime = true;
        _spawnAction = new RoutineBehaviour.TimedAction();
    }

    private void Update()
    {
        if (!_spawnTime && !_spawnAction.IsActive) 
        {
            _spawnTime = true;
            _spawnAction = RoutineBehaviour.Instance.StartNewTimedAction(args => { _spawnTime = false; SpawnRandomEnemy(); }, TimedActionCountType.SCALEDTIME, 3.5f);
        }

        if (Input.GetKeyDown(KeyCode.X) && !_skipCheck) 
        {
            _skipCheck = true;
            InstantRun();
        }
    }

    public void StartRun() 
    {
        StartCoroutine(BeginRun());
    }

    IEnumerator BeginRun() 
    {
        _dialogueManager.SetCurrentDialogue(null);
        _hasred.GetComponent<Animator>().SetTrigger("disappear");
        yield return new WaitForSeconds(5.5f);
        _hasred.SetActive(false);
        _chamber.SetActive(true);
        _playerMovement.enabled = true;
        _combatBehaviour.enabled = true;
        _chamberBehaviour.enabled = true;
        _spawnTime = false;
    }

    void InstantRun() 
    {
        _dialogueManager.SetCurrentDialogue(null);
        _hasred.SetActive(false);
        _chamber.SetActive(true);
        _playerMovement.enabled = true;
        _combatBehaviour.enabled = true;
        _chamberBehaviour.enabled = true;
        _spawnTime = false;
    }

    void SpawnRandomEnemy() 
    {
        Vector3 randomPoint = new Vector3(Random.Range(-130.0f, 130.0f), 0.5f, Random.Range(-130.0f, 130.0f));
        NavMeshHit hit;
        while (!NavMesh.SamplePosition(randomPoint, out hit, Mathf.Infinity, NavMesh.AllAreas)) 
        {
            randomPoint = new Vector3(Random.Range(-130.0f, 130.0f), 0.5f, Random.Range(-130.0f, 130.0f));
        }
        Instantiate(_enemy, randomPoint, Quaternion.identity);
    }
}
