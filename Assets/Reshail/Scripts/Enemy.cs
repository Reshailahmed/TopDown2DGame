using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Enemy : MonoBehaviour
{
    Animator animator;
    public Transform player;
    public GameObject fireballPrefab;
    public float moveSpeed = .005f;
    public float health = 1;
    public AIPath aipath;
    SpriteRenderer spriteRenderer;
    public float fireballSpeed = .01f;
    public float fireballCooldown = 2f;
    public float distanceToShoot = 8f;
    public float timeToFire = 3f;
    public float fireRate = 8f;
    public Transform firingPoint;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (aipath.desiredVelocity.x >= 0.01f)
        {
            spriteRenderer.flipX = false;
        }
        else if(aipath.desiredVelocity.x <= 0.01f)
        {
            spriteRenderer.flipX = true;
        }

        player = GameObject.FindGameObjectWithTag("Player").transform;
        if(Vector2.Distance(player.position,transform.position) <= distanceToShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if(timeToFire <= 0f)
        {
            GameObject fireball = Instantiate(fireballPrefab, firingPoint.position, firingPoint.rotation);
            timeToFire = fireRate;
        }
        else
        {
            timeToFire -= Time.deltaTime;
        }
    }

    public float Health {
        set {
            health = value;

            if(health <= 0) {
                Defeated();
            }
        }
        get {
            return health;
        }
    }

    public void Defeated(){
        animator.SetTrigger("Defeated");
    }

    public void RemoveEnemy() {
        Destroy(gameObject);
    }
}
