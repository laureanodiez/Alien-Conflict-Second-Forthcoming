using UnityEngine;
using UnityEngine.AI;

public class EnemyAITutorial : MonoBehaviour
{
    public Animator animator;

    public NavMeshAgent agent;

    public GameObject player;
    public Transform listener;

    public LayerMask whatIsGround, whatIsPlayer;

    public float salud;

    int contador;
    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    public float timeBetweenAttacks;
    bool alreadyAttacked;

    //States
    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    public int puntuacion;

    public void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Awake()
    {
        player = GameObject.Find("Player");
        listener = GameObject.Find("listener").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    public void recibirDanio(int valor){
        salud = salud - valor;
        if (salud <= 0 && contador == 0) { 
            contador++;
            Invoke(nameof(DestroyEnemy), 0.2f);
        }
    }

    private void DestroyEnemy()
    {
        player.GetComponent<Jugador>().incremento(puntuacion);
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

        //Walking animation starts
        animator.SetBool("isWalking", true);
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
        //Walking animation continues
        animator.SetBool("isWalking", true);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(listener);

        //Walking animation stops
        animator.SetBool("isWalking", false);

        if (!alreadyAttacked)
        {
            if(gameObject.GetComponent<DispararEnemigo>() != null) {
                gameObject.GetComponent<DispararEnemigo>().ataque();
            }
            if(gameObject.GetComponent<AtaqueMelee>() != null) {
                gameObject.GetComponent<AtaqueMelee>().ataque();
            }

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
