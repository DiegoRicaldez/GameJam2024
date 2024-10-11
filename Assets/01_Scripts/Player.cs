using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int maxLife = 3;
    public int life = 0;

    public float speed = 5f;
    private Vector3 vectorVertical = Vector3.forward;
    private Vector3 vectorHorizontal = Vector3.left;
    private int anteriorR = 0, r = 0;
    public Rigidbody rb;
    
    void Start()
    {
        life = maxLife;
    }

    void Update()
    {
        Move();

        if (Input.GetKeyDown(KeyCode.Tab)) // borrar despues
            ChangeOrientation();
    }

    private void Move()
    {
        float x = Input.GetAxis("Vertical");
        float z = Input.GetAxis("Horizontal");

        rb.velocity = vectorVertical * speed * z
            + vectorHorizontal * speed * x;
    }

    public void ChangeOrientation()
    {
        do
        {
            r = Random.Range(1, 8);
        }
        while (anteriorR != 0 && r == anteriorR);

        switch (r)
        {
            case 1:
                vectorVertical = Vector3.forward;
                vectorHorizontal = Vector3.right;
                break;
            case 2:
                vectorVertical = Vector3.right;
                vectorHorizontal = Vector3.back;
                break;
            case 3:
                vectorVertical = Vector3.back;
                vectorHorizontal = Vector3.left;
                break;
            case 4:
                vectorVertical = Vector3.left;
                vectorHorizontal = Vector3.forward;
                break;
            case 5:
                vectorVertical = Vector3.forward;
                vectorHorizontal = Vector3.left;
                break;
            case 6:
                vectorVertical = Vector3.left;
                vectorHorizontal = Vector3.back;
                break;
            case 7:
                vectorVertical = Vector3.back;
                vectorHorizontal = Vector3.right;
                break;
            case 8:
                vectorVertical = Vector3.right;
                vectorHorizontal = Vector3.forward;
                break;
        }

    }

    public void ResetOrientation()
    {
        vectorVertical = Vector3.forward;
        vectorHorizontal = Vector3.left;
    }
}
