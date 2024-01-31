using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using Random = UnityEngine.Random;

public class LevelManager : MonoBehaviour
{
    /* The LevelManager manages aspects of the particular level. It might hold values on the difficulty of the level with:
            - How frequently the lights turn off
            - How frequently the enemies' eyes light up
            - How quickly the Pacman's flashlight runs out
            - etc...
            
        The LevelManager should hold references the enemies of the current level, not the GameManager.
    */

    public List<GameObject> enemyPrefabs;
    public List<Vector2> enemySpawnPositions;

    private List<Enemy> activeEnemies;

    public LevelStateMachine stateMachine;

    public int nodesRemaining;
    public int levelScore;
    
    // references to states
    public LevelDarkState darkState;
    public LevelLightState lightState;

    private bool levelOver;
    
    // Start is called before the first frame update
    void Start()
    {
        this.stateMachine = new LevelStateMachine();

        this.darkState = new LevelDarkState(this, stateMachine, "Dark");
        this.lightState = new LevelLightState(this, stateMachine, "Light");
        
        stateMachine.Initialize(lightState);
        
        SpawnGhosts();
    }

    // Update is called once per frame
    void Update()
    {
        if (nodesRemaining <= 0 && !levelOver)
        {
            EndLevel(true);
            levelOver = true;
        }
    }

    private void SpawnGhosts()
    {
        activeEnemies = new List<Enemy>();
        
        for (int i = 0; i < enemyPrefabs.Count; i++)
        {
            GameObject enemyObject = Instantiate(enemyPrefabs[i], enemySpawnPositions[i], Quaternion.identity);
            Enemy enemyScript = enemyObject.GetComponent<Enemy>();
            
            activeEnemies.Add(enemyScript);
            enemyScript.SetSpawnPosition(enemySpawnPositions[i]);
        }
    }

    public void StartGhostRespawnTimer(GameObject enemyGO)
    {
        enemyGO.SetActive(false);
        StartCoroutine(DoGhostRespawnTimer(enemyGO));
    }

    private IEnumerator DoGhostRespawnTimer(GameObject enemyGO)
    {
        yield return new WaitForSeconds(GameParameters.ghostRespawnTime);
        
        enemyGO.SetActive(true);
        
        Enemy enemyScript = enemyGO.GetComponent<Enemy>();
        enemyGO.transform.position = enemyScript.GetSpawnPosition();
        enemyScript.stateMachine.ChangeState(enemyScript.normalState);

        Node[] nodes = FindObjectsByType<Node>(FindObjectsSortMode.None);
        enemyGO.GetComponent<EnemyMovementController>().currentNode = nodes[Random.Range(0,nodes.Length)].gameObject;
    }

    public void EndLevel(bool won)
    {
        Singleton.Instance.GameManager.LevelComplete(levelScore, won);
    }

    public void CollectNode()
    {
        levelScore += GameParameters.nodeScoreValue;
        nodesRemaining -= 1;
    }

    public void CollectFruit()
    {
        levelScore += GameParameters.fruitScoreValue;
        nodesRemaining -= 1;
    }

    public void CollectPowerup()
    {
        levelScore += GameParameters.nodeScoreValue;
        nodesRemaining -= 1;
    }

    public void CollectGhost()
    {
        levelScore += GameParameters.ghostScoreValue;
    }

    public void MakeGhostsVulnerable()
    {
        Enemy[] ghosts = FindObjectsByType<Enemy>(FindObjectsSortMode.None);
        foreach (Enemy ghost in ghosts)
        {
            ghost.stateMachine.ChangeState(ghost.vulnerableState);
        }
    }
}
