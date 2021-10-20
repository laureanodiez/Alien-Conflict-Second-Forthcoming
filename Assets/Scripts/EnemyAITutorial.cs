using UnityEngine;
using UnityEngine.AI;

public class EnemyAITutorial : MonoBehaviour
{
    public NavMeshAgent agent;

    public GameObject player;
    public Transform listener;

    public LayerMask whatIsGround, whatIsPlayer;

    public float salud;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;
    public GameObject projectile;
    public Transform attackPoint;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    private void Awake()
    {
        player = GameObject.Find("Player");
        listener = GameObject.Find("listener").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    public void recibirDanio(int valor){
        salud = salud - valor;

        if (salud <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }

    private void DestroyEnemy()
    {
        // player.GetComponent<Jugador>.incremento(1);
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Bala")){
            recibirDanio(10);
        }
    }

    private void Update()
    {
        //Check for sight and attack range
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (!playerInSightRange && !playerInAttackRange) Patroling();
        if (playerInSightRange && !playerInAttackRange) ChasePlayer();
        if (playerInAttackRange && playerInSightRange) AttackPlayer();
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

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(player.transform.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(listener);

        if (!alreadyAttacked)
        {
            ///Attack code here
            Vector3 direction = listener.position - attackPoint.position; // + new Vector3(0,listener.position.y,0)
            GameObject currentBullet = Instantiate(projectile, attackPoint.position, Quaternion.identity);
            currentBullet.transform.forward = direction.normalized;

            Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
            rb.AddForce(direction.normalized * 15f, ForceMode.Impulse);
            ///End of attack code

            // gameObject.GetComponent<DispararEnemigo>().ataque();

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
