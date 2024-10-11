using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public List<GameObject> pathPrefabs;
    public List<GameObject> WallPrefabs;

    public Queue<GameObject> actualPaths;
    public Queue<GameObject> actualWalls;

    public Vector3 nextPathPosition;
    public Vector3 nextWallPosition;
    public float distancia = 10f;
    public int maxCount = 8;

    public Transform startPoint;

    void Start()
    {
        actualPaths = new Queue<GameObject>();
        actualWalls = new Queue<GameObject>();

        nextPathPosition.z = startPoint.transform.position.z;
        nextWallPosition.z = startPoint.transform.position.z;

        while (actualPaths.Count < maxCount)
            Generate();
    }

    // que se active al pisar un colider del piso
    private void Generate() 
    {
        if (pathPrefabs.Count < maxCount)
        {
            actualPaths.Enqueue(Instantiate(pathPrefabs[Random.Range(0, pathPrefabs.Count)], nextPathPosition, Quaternion.identity));
            actualWalls.Enqueue(Instantiate(WallPrefabs[Random.Range(0, pathPrefabs.Count)], nextWallPosition, Quaternion.identity));

            nextPathPosition.z += distancia;
            nextWallPosition.z += distancia;
        }
    }

    public void Advance()
    {
        Destroy(actualPaths.Dequeue());
        Destroy(actualWalls.Dequeue());

        Generate();
    }
}
