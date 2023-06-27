using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathSpawner : MonoBehaviour
{
    public GameObject[] paths;
    public float zSpawn = 0;
    public float pathLength = 33;
    public int maxNumOfPaths = 4;
    public List<GameObject> activePaths = new List<GameObject>();

    public Transform playerTransform;

    public PathMover pathMover;

    private bool pathsMoving = true; 

    private void Start()
    {
        SpawnInitialPaths();
    }

    private void Update()
    {
        if (activePaths.Count < maxNumOfPaths && playerTransform.position.z > zSpawn - (pathLength * (maxNumOfPaths - 1)))
        {
            SpawnPath();
        }

        if (pathsMoving)
            pathMover.MovePaths();

        if (activePaths.Count > 0 && activePaths[0].transform.position.z < playerTransform.position.z - pathLength)
        {
            DeletePath();
        }
    }

    public void SpawnInitialPaths()
    {
        GameObject firstPathPrefab = paths[0];

        Vector3 spawnPosition = Vector3.zero + playerTransform.right * -2 + Vector3.forward * zSpawn;

        GameObject instantiatedFirstPath = Instantiate(firstPathPrefab, spawnPosition, Quaternion.identity);
        instantiatedFirstPath.transform.Rotate(0, 90, 0);
        instantiatedFirstPath.transform.SetParent(transform);

        activePaths.Add(instantiatedFirstPath);

        zSpawn += pathLength;

        // Spawn the remaining paths randomly.
        for (int i = 1; i < maxNumOfPaths; i++)
        {
            SpawnPath();
        }
    }

    public void SpawnPath()
    {
        int randomIndex = Random.Range(0, paths.Length);
        GameObject pathPrefab = paths[randomIndex];

        Vector3 spawnPosition = activePaths[activePaths.Count - 1].transform.position + Vector3.forward * pathLength;

        GameObject instantiatedPath = Instantiate(pathPrefab, spawnPosition, Quaternion.identity);
        instantiatedPath.transform.Rotate(0, 90, 0);
        instantiatedPath.transform.SetParent(transform);

        activePaths.Add(instantiatedPath);
    }

    private void DeletePath()
    {
        Destroy(activePaths[0]);
        activePaths.RemoveAt(0);
    }

    public void StopPathMovement()
    {
        pathsMoving = false;
    }
}

