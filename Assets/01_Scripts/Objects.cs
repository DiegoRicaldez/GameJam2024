using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    public ObjectType type = ObjectType.cheese;

    public float rotationSpeed = 2f;
    public float lifeTime = 30f;

    private void Start()
    {
        Destroy(gameObject,lifeTime);
    }

    void Update()
    {
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}

public enum ObjectType
{
    cheese,
    chili,
    poison
}
