using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public List<GameObject> pathPrefabs;
    public List<GameObject> WallPrefabs;
    public backWall backWall;

    public Queue<GameObject> actualPaths;
    public Queue<GameObject> actualWalls;

    public Vector3 nextPathPosition;
    public Vector3 nextWallPosition;
    public float distancia = 10f;
    public int maxCount = 8;

    public Transform startPoint;

    void Start()
    {
        Instantiate(backWall, new Vector3(0, nextWallPosition.y, startPoint.position.z), Quaternion.identity);

        actualPaths = new Queue<GameObject>();
        actualWalls = new Queue<GameObject>();

        nextPathPosition.z = startPoint.transform.position.z;
        nextWallPosition.z = startPoint.transform.position.z;

        int medio = (maxCount / 2) - 1;

        for (int i = 0; i < maxCount; i++)
        {
            if (i < medio)
                GenerateStart();
            else
                Generate();
        }
    }

    // que se active al pisar un colider del piso
    private void Generate() 
    {
        if (pathPrefabs.Count < maxCount)
        {
            actualPaths.Enqueue(Instantiate(pathPrefabs[Random.Range(0, pathPrefabs.Count)], nextPathPosition, Quaternion.identity));
            actualWalls.Enqueue(Instantiate(WallPrefabs[Random.Range(0, WallPrefabs.Count)], nextWallPosition, Quaternion.identity));

            nextPathPosition.z += distancia;
            nextWallPosition.z += distancia;
        }
    }

    // que se active al pisar un colider del piso
    private void GenerateStart()
    {
        if (pathPrefabs.Count < maxCount)
        {
            var aux = Instantiate(pathPrefabs[Random.Range(0, pathPrefabs.Count)], nextPathPosition, Quaternion.identity);

            aux.GetComponent<Floor>().activated = true;

            actualPaths.Enqueue(aux);
            actualWalls.Enqueue(Instantiate(WallPrefabs[Random.Range(0, WallPrefabs.Count)], nextWallPosition, Quaternion.identity));

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
