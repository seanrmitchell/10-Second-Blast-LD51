using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Controller playerController;

    [SerializeField] //visible in editor
    private float maxSpeed, speed;

    [SerializeField]
    private Transform groundCheck;

    [SerializeField]
    private LayerMask groundObjects;
    private Camera cam;

    [SerializeField]
    private Rigidbody2D rb;

    Vector2 movement;

    private void Awake()
    {
        playerController = new Controller();
    }
    private void OnEnable()
    {
        playerController.Enable();
    }

    private void OnDisable()
    {
        playerController.Disable();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Flip();

    }

    private void FixedUpdate()
    {
        // Gets horizontal input
        movement.y = playerController.Gameplay.WS.ReadValue<float>();
        movement.x = playerController.Gameplay.AD.ReadValue<float>();


        // calculates movement on ground
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
        //Vector2 playerMove = new Vector2(Mathf.Clamp(movement * speed, -maxSpeed, maxSpeed), rb.velocity.y);
    }

    private void Flip()
    {
        if (rb.velocity.x > 0f)
            gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        if (rb.velocity.x < 0f)
            gameObject.transform.localScale = new Vector3(-1f, 1f, 1f);

    }

    private void Attack(int x)
    {
        switch (x)
        {
            case 1:
                Debug.Log("Primary Attack!");
                break;
            case 2:
                Debug.Log("Special Attack!");
                break;
        }
    }


}

