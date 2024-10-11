using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform playerToFollow;

    void Start()
    {
        playerToFollow = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, playerToFollow.position.z);
    }
}
