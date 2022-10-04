using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField]
    private float enemySpawnMulti, enemySpawnNumber, spawnCoolDown;

    Vector2 spawnPoint;

    [SerializeField]
    private GameObject enemyPrefab;
    
    [SerializeField]
    private Rigidbody2D playerRB;

    private int randomSpawnZone;
    private float randomX, randomY;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnZone", 3f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnZone()
    {
        Debug.Log("Spawn!" + enemySpawnNumber);
        for (int i = 0; i <= enemySpawnNumber; i++)
        {
            randomSpawnZone = Random.Range(0, 4);

            switch (randomSpawnZone)
            {
                case 0:
                    randomX = Random.Range(-20f, -10f);
                    randomY = Random.Range(-20f, -10f);
                    break;
                case 1:
                    randomX = Random.Range(-10f, 0f);
                    randomY = Random.Range(-10f, 0f);
                    break;
                case 2:
                    randomX = Random.Range(0f, 10f);
                    randomY = Random.Range(-10f, 0f);
                    break;
                case 3:
                    randomX = Random.Range(0f, 10f);
                    randomY = Random.Range(0f, 10f);
                    break;
            }

            spawnPoint = new Vector2(randomX, randomY);
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
            //enemy.GetComponent<Enemy>().playerBody = playerRB;
        }
    }
}
