using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backWall : MonoBehaviour
{
    public float maxDistance = 20f;
    public float speed = 3f;
    private Player player;
    private Rigidbody rb;

    public bool canMove = false;

    void Start()
    {
        player = FindObjectOfType<Player>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (canMove)
        {
            if (player != null && player.transform.position.z - transform.position.z >= maxDistance)
            {
                //rapido
                rb.velocity = Vector3.forward * speed * player.speed;
                Debug.Log("rapido");
            }
            else
            {
                //normal
                rb.velocity = Vector3.forward * speed;
                Debug.Log("normal");
            }
        }
    }
}
