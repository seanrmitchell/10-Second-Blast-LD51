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

    [SerializeField]
    private Rigidbody2D player;

    private Transform target ;


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

    /*
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            target = null;
            Debug.Log("no target");
        }
    }

    
    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            if(attackSpeed <= canAttack)
            {
                col.gameObject.GetComponent<PlayerConditions>().UpdateHealth(-damage);
                canAttack = 0f;
            } else
            {
                canAttack += Time.deltaTime;
            }
            
        }
    }
    */

    void Awake()
    {
        target = player.transform;
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



    /*
    private bool PlayerInSight()
    {
        RaycastHit2D hit = Physics2D.BoxCast(box.bounds.center + transform.right * range * transform.localScale.x, box.bounds.size, 0, Vector2.left, 0, playerLayer);
        return hit.collider != null;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(box.bounds.center + transform.right * range * transform.localScale.x, box.bounds.size);
    }
    */
}
