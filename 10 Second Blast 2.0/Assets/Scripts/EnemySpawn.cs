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

    private int randomSpawnZone;
    private float randomX, randomY;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnZone", 0f, 10f);
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
                    randomX = Random.Range(-11f, -10f);
                    randomY = Random.Range(-8f, -8f);
                    break;
                case 1:
                    randomX = Random.Range(-10f, -10f);
                    randomY = Random.Range(-7f, -8f);
                    break;
                case 2:
                    randomX = Random.Range(10f, 11f);
                    randomY = Random.Range(-8f, 8f);
                    break;
                case 3:
                    randomX = Random.Range(-10f, 10f);
                    randomY = Random.Range(7f, 8f);
                    break;
            }

            spawnPoint = new Vector2(randomX, randomY);
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint, Quaternion.identity);
        }
        enemySpawnNumber *= enemySpawnMulti;
    }
}
