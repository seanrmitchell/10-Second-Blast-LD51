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

    public GameOver gameOver;


    private Transform hit;

    private void Start()
    {
        health = maxHealth;
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
}
