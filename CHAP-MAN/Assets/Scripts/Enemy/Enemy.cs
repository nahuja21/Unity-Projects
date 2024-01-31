using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Sprite normalSprite, vulnerableSprite;
    
    public EnemyStateMachine stateMachine;

    public EnemyNormalState normalState;
    public EnemyVulnerableState vulnerableState;

    private Vector2 spawnPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        this.stateMachine = new EnemyStateMachine();

        this.normalState = new EnemyNormalState(this, stateMachine, "Normal");
        this.vulnerableState = new EnemyVulnerableState(this, stateMachine, "Vulnerable");
        
        stateMachine.Initialize(normalState);
    }

    // Update is called once per frame
    void Update()
    {
        stateMachine.currentState.HandleInput();
        stateMachine.currentState.LogicUpdate();
    }

    public void SetSpawnPosition(Vector2 pos) => spawnPosition = pos;

    public Vector2 GetSpawnPosition() => spawnPosition;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Pacman")) return;
        
        stateMachine.currentState.OnTriggerEnter2D(other);
    }

    public void EatenByPacman()
    {
        stateMachine.ChangeState(normalState);
        FindObjectOfType<LevelManager>().StartGhostRespawnTimer(gameObject);
    }

    public void SetSprite(bool vulnerable)
    {
        GetComponent<SpriteRenderer>().sprite = vulnerable ? vulnerableSprite : normalSprite;
    }
}
