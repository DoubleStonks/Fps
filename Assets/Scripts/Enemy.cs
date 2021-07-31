using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[RequireComponent (typeof (NavMeshAgent))]

public class Enemy : MonoBehaviour
{

    public float attackDistance = 20f;
    public float MovementSpeed = 7.5f;
    public int Damage = 10;
    public float fireRate = 1f;
    public Transform firePoint;
    public ParticleSystem muzzleflash;


    public Transform Player;

    NavMeshAgent Agent;
    float NextAtkTime = 0;
    Rigidbody enemy;


    // Start is called before the first frame update
    void Start()
    {
        enemy = GetComponent<Rigidbody>();
        enemy.useGravity = false;
        enemy.isKinematic = true;
        Agent = GetComponent<NavMeshAgent>();
        Agent.stoppingDistance = attackDistance;
        Agent.speed = MovementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Agent.remainingDistance - attackDistance < 0.01f)
        {
            if (Time.time > NextAtkTime)
            {
                NextAtkTime = Time.time + fireRate;
                RaycastHit Hit;
                if (Physics.Raycast(firePoint.position, firePoint.forward, out Hit, attackDistance))
                {
                    if (Hit.transform.CompareTag("Player"))
                    {
                        Debug.DrawLine(firePoint.position, firePoint.position + firePoint.forward * attackDistance, Color.blue);

                        muzzleflash.Play();

                        var health = Hit.collider.GetComponent<Health>();

                        if (health != null)
                        {
                            health.TakeDamage(Damage);
                        }
                    }
                }
            }
        }

        Agent.destination = Player.position;
        transform.LookAt(new Vector3(Player.position.x, transform.position.y, Player.position.z));
        enemy.velocity *= .99f;

    }
}
