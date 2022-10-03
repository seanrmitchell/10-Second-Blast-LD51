using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField]
    private float damage, speed;

    private float attackSpeed;

    [SerializeField]
    private float attackCoolDown;

    [SerializeField]
    private BoxCollider2D box;

    [SerializeField]
    private LayerMask playerLayer;

    private Transform target ;

    void Awake()
    {
        target = GameObject.Find("Player").transform;
    }

    private void Start()
    {
        attackSpeed = attackCoolDown;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (attackSpeed >= attackCoolDown)
            {
                other.gameObject.GetComponent<PlayerConditions>().UpdateHealth(-damage);
                attackSpeed = 0f;
            }
        }

        if (other.gameObject.tag == "Laser")
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector2.MoveTowards(transform.position, target.position, step);

        if(attackSpeed < attackCoolDown)
        {
            attackSpeed += Time.deltaTime;
        }
        
        
    }
}
