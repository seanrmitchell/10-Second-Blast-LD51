using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public Transform firePoint;
    public GameObject laserPrefab;
    public Camera cam;

    Vector2 mousePos;

    [SerializeField]
    Rigidbody2D player;

    [SerializeField]
    private float laserForce;

    private Controller playerController;

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

    private void FixedUpdate()
    {
        playerController.Gameplay.Shoot1.performed += _ => Shoot();

        mousePos = playerController.Gameplay.MousePosition.ReadValue<Vector2>();
    }
    // Update is called once per frame
    void Update()
    {

    }

    void Shoot()
    {
        GameObject laser = Instantiate(laserPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = laser.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * laserForce, ForceMode2D.Impulse);
    }
}
