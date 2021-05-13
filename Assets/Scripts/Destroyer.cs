using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    private GameObject player;

    // get the player
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // "delete" the obstacles that are behind the player
    void Update()
    {
        if (gameObject.transform.position.z < player.transform.position.z - 15)
        {
            Destroy(gameObject);
        }
    }
}
