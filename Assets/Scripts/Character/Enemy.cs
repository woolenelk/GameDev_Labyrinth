using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Entity
{
    [SerializeField]
    public float AttackTimer;
    [SerializeField]
    public float MaxAttackTimer = 5;
    [SerializeField]
    bool canShootPlayer = false;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private GameObject player;
    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private float timer;

    [SerializeField]
    GameObject bullet;
    [SerializeField]
    Transform bulletspawn;

    // Use this for initialization
    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        AttackTimer -= Time.deltaTime;
        if (player != null)
        {
            if (AttackTimer <= 0)
            {
                agent.SetDestination(player.transform.position);
                Vector3 dir = ((player.transform.position + new Vector3 (0, 1f,0)) - bulletspawn.position).normalized;
                Debug.Log(Quaternion.Euler(dir));
                if (canShootPlayer)
                {
                    Instantiate(bullet, bulletspawn.position, Quaternion.LookRotation(dir));
                    AttackTimer = MaxAttackTimer;
                    timer = 0;
                }
            }
            // see player
            else if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }
        }
        else
        {
            //haven't seen player patrol around

            if (timer >= wanderTimer)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);
                timer = 0;
            }
        }
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject;
            canShootPlayer = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            canShootPlayer = false;
        }
    }
}
