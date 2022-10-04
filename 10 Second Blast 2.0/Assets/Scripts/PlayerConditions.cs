using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerConditions : MonoBehaviour
{
    [SerializeReference]
    private float health = 0f;
    [SerializeField]
    private float maxHealth = 3f;
    [SerializeField]
    private Rigidbody2D rb;

    public GameOver gameOver;

    public DeathBox outsideBox;



    private Transform hit;

    

    private void Start()
    {
        health = maxHealth;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            UpdateHealth(-1);
        }
    }

    public void UpdateHealth(float mod)
    {
        health += mod;

        if (health > maxHealth)
        {
            health = maxHealth;
        } else if (health <= 0f)
        {
            health = 0f;
            gameOver.DetermineGameOver();
        }
    }

    void Update()
    {
        if (outsideBox.IsOutsideBox(rb.position))
        {
            UpdateHealth(-outsideBox.damageOfBox);
        }

        /*
        else if(outsideBox.gameObject.GetComponent<DeathBox>().coolDownBox >= 10)
        {
            outsideBox.gameObject.GetComponent<DeathBox>().coolDownBox = 10f;
        }
        */
    }
}
