using UnityEngine;
using System.Collections.Generic;

public class EnemyManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;
    public int spawnCap = 10;
    private Queue<GameObject> enemyPool = new Queue<GameObject>();
   // private EnemyHealth enemyHealth;

    void Start ()
    {
        EnemyHealth healthComponent = enemy.GetComponent<EnemyHealth>();

        for(int i = 0; i < spawnCap; i++)
        {
            EnemyHealth pooledEnemy = Instantiate<EnemyHealth>(healthComponent);
            pooledEnemy.enemyPool = this;
            enemyPool.Enqueue(pooledEnemy.gameObject);
            pooledEnemy.gameObject.SetActive(false);
        }

        InvokeRepeating (nameof(Spawn), spawnTime, spawnTime);
    }

    void Spawn ()
    {
        if(playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range (0, spawnPoints.Length);

        //Instantiate (enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);

        if(enemyPool.Count > 0)
        {
        GameObject enemy = enemyPool.Dequeue ();
        enemy.SetActive (true);
        enemy.transform.position = spawnPoints[spawnPointIndex].position;
        enemy.transform.rotation = spawnPoints[spawnPointIndex].rotation;
        }

    }

    public void AddToQueue(GameObject enemyPrefab)
    {
        enemyPool.Enqueue (enemyPrefab);
    }
}
