using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{

    public GameObject player;
    public GameObject[] trianglePrefabs;
    public GameObject[] coinPrefabs;
    private Vector3 spawnObstaclePosition;
    private Vector3 spawnCoinPosition;

    void Update()
    //  "new obstacles" infront off the player obj
    {
        float distanceToHorizon = Vector3.Distance(player.gameObject.transform.position, spawnObstaclePosition);
        if (distanceToHorizon < 120)
        {
            SpawnTriangles();
            SpawnCoins();
        }
    }

    //here be obstacles spawner
    void SpawnTriangles()
    {
        spawnObstaclePosition = new Vector3(0, 0, spawnObstaclePosition.z + 30);
        Instantiate(trianglePrefabs[(Random.Range(0, trianglePrefabs.Length))], spawnObstaclePosition, Quaternion.identity);
    }//here be coin spawner
    void SpawnCoins()
    {
        spawnCoinPosition = new Vector3(0, 0, spawnCoinPosition.z + Random.Range(55, 199));
        Instantiate(coinPrefabs[(Random.Range(0, coinPrefabs.Length))], spawnCoinPosition, Quaternion.identity);
    }
}