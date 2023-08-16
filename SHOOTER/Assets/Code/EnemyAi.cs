using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public AudioSource src;
    public AudioClip sfx1;
    public NavMeshAgent agent;
    
    public Transform player;
    
    public LayerMask whatIsGrounded, whatIsPlayer;
    
    public float health;
    public float damage1 = 5f;
    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;
    public GameObject bullet;
    public Transform bulletTransform;
    int playerGold = 0;
    int playerExp = 0;

    
    //Attacking
    
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject enemyPrefab;
    public ParticleSystem EnemyMuzzleFlash;
    
    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;
    
    public bool enemyInSightRange, enemyInAttackRange;
    
    
    private void Awake()
    {
        
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

    void Start() 
    {
        
        

    }
    
    private void Update()
    {

        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        
        if (!playerInSightRange && !playerInAttackRange && !enemyInSightRange && !enemyInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange || enemyInSightRange && !enemyInAttackRange) Chase();
        if (playerInAttackRange && playerInSightRange) Attack();

    }
    
    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();
        
        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        
        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGrounded))
            walkPointSet = true;
    }
    
    private void Chase()
    {
        agent.SetDestination(player.position);
        transform.LookAt(player);
    }

void Attack()
{
    transform.LookAt(player);
    agent.SetDestination(transform.position);
    
 
    if (!alreadyAttacked)
    {
        // Attack code here
        src.clip = sfx1;
        src.Play();
        ShootPlayer();
        // End of attack code
 
        alreadyAttacked = true;
        Invoke(nameof(ResetAttack), timeBetweenAttacks);
    }
}
    
    
    void ShootPlayer()
    {
    
    RaycastHit hit;
    
    
    
    if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange)){
        
        Shootingcode shootingcode = FindObjectOfType<Shootingcode>();
        
        EnemyMuzzleFlash.Play();
        
        
            if(hit.collider.CompareTag("Player"))
            {
                
            shootingcode.TakeDamage1(damage1);
            }
            
        
    }
    }
    
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
    
    // how enemy takes damage from player
    public void TakeDamage(float damage)
    {
        health -= damage;
        
        if (health <= 0)
        {
            DestroyEnemy();


            
            
        }
    }

    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

 
    
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
