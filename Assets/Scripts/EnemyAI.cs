using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UIElements;
public class EnemyAI : MonoBehaviour
{
    public NavMeshAgent agent;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public int attackDamage = 1;
    public float attackChargeUpTimer;
    public float attackChargeUpLength = 1f;

    //states
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    public float stunTimer;
    public float stunLength = 2f;
    public float waitTimer;
    public float waitLength = 2f;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //check for sign or attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (stunTimer > 0)
        {
            stunTimer -= Time.deltaTime;
            agent.SetDestination(transform.position);
            return;
        }
        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInSightRange && playerInAttackRange) AttackPlayer();
    }

    public void GetStunned()
    {
        stunTimer += stunLength;
    }
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet) agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
        {
            if (waitTimer > 0)
            {
                waitTimer -= Time.deltaTime;
                return;
            }
            waitTimer += waitLength;
            walkPointSet = false;
        }
    }

    private void SearchWalkPoint()
    {
        float randomz = Random.Range(-walkPointRange, walkPointRange);
        float randomx = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomx, transform.position.y, transform.position.z + randomz);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }
    private void ChasePlayer()
    {
        agent.SetDestination(player.position);
    }
    private void AttackPlayer()
    {
        //make sure enemy doesn't move
        agent.SetDestination(transform.position);

        Vector3 playerPos = player.position;
        playerPos.y = transform.position.y;

        transform.LookAt(playerPos);

        if (!alreadyAttacked)
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, attackRange);
            foreach (Collider col in colliders)
            {
                if (col.tag == "Player")
                {
                    Health hp = col.gameObject.GetComponent<Health>();
                    if (hp != null)
                    {
                        hp.health -= attackDamage;
                    }
                }
            }

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
       alreadyAttacked = false;
    }
}
