using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPlayerMoveSensor : MonoBehaviour
{
    Player player;
    Vector3 playerStart;

    void Start()
    {
        player = FindObjectOfType<Player>();

        playerStart = player.transform.position;
    }

    void Update()
    {
        if (player.transform.position != playerStart)
        {
            FindObjectOfType<backWall>().canMove = true;
            Destroy(gameObject);
        }
    }
}
