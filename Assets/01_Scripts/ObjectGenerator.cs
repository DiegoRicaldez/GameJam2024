using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGenerator : MonoBehaviour
{
    public List<Objects> objectsPrefabs;

    public Transform BottomLeft;
    public Transform TopRight;

    public float SpawnTime = 5f;
    public float Spawndecrease = 0.2f;
    public int decreaseAmount = 20;
    public float secondSpawnTime = 1.5f;
    public int secondDecreaseAmount = 50;

    private float timer = 0f;
    private int amount = 0;
    private int secondAmount = 0;

    public bool canSpawn = false;

    void Update()
    {
        if (canSpawn)
        {
            if (timer < SpawnTime)
            {
                timer += Time.deltaTime;
            }
            else
            {
                float x = Random.Range(BottomLeft.position.x, TopRight.position.x);
                float z = Random.Range(BottomLeft.position.z, TopRight.position.z);
                Vector3 pos = new Vector3(x, transform.position.y, z);

                Instantiate(objectsPrefabs[Random.Range(0, objectsPrefabs.Count)], pos, Quaternion.identity);

                timer = 0;
                amount++;

                if (amount >= decreaseAmount)
                {
                    if (SpawnTime > secondSpawnTime)
                    {
                        SpawnTime -= Spawndecrease;
                    }
                    else
                    {
                        secondAmount++;

                        if (secondAmount >= secondDecreaseAmount)
                        {
                            SpawnTime -= Spawndecrease;
                            secondAmount = 0;
                        }
                    }

                    amount = 0;

                }
            }
        }
    }
}
