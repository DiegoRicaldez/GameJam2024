using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollowPlayer : MonoBehaviour
{
    public float spawnTime = 4f;
    private float timer = 0;
    public bool spawned = false;
    public float baseSpeed;

    Player player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        baseSpeed = player.speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawned)
        {
            Rotate();
            Move();
        }
        else
        {
            if (timer < spawnTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                spawned = true;
                timer = 0;
            }
        }

    }

    private void Move()
    {
        if (player != null)
        {
            Vector3 direction = player.transform.position - transform.position;
            direction.y = 0; 

            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, baseSpeed * Time.deltaTime);
        }
    }

    void Rotate()
    {
        if (player != null)
        {
            transform.LookAt(player.transform);
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
        }
        else
        {
            player = FindObjectOfType<Player>();
        }
    }
}
