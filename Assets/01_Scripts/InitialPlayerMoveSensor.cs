using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialPlayerMoveSensor : MonoBehaviour
{
    Player player;
    Vector3 playerStart;
    backWall backWall;

    void Start()
    {
        player = FindObjectOfType<Player>();
        backWall = FindObjectOfType<backWall>();

        playerStart = player.transform.position;
    }

    void Update()
    {
        if (player.transform.position != playerStart)
        {
            backWall.canMove = true;
            Debug.Log("activado");
            Destroy(gameObject);
        }
    }
}
