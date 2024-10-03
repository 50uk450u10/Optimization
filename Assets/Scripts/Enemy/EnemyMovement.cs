using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    EnemyHealth enemyHealth;
    PlayerHealth playerHealth;
    NavMeshAgent agent;
    Transform player;

    private void Start()
    {
        enemyHealth = GetComponent<EnemyHealth>();
        playerHealth = FindObjectOfType<PlayerHealth>();
        agent = GetComponent<NavMeshAgent>();
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    void Update ()
    {
        if (enemyHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            agent.SetDestination (player.position);
        }
        else
        {
            agent.enabled = false;
        }

    }
}
