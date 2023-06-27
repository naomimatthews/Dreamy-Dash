using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMover : MonoBehaviour
{
    public float moveSpeed = 10f;
    public Transform target;

    private bool movingEnabled = true; 

    public void MovePaths()
    {
        if (!movingEnabled)
            return;

        foreach (Transform child in transform)
        {
            Vector3 targetPosition = new Vector3(child.position.x, child.position.y, target.position.z + child.localPosition.z);
            child.position = Vector3.MoveTowards(child.position, targetPosition, moveSpeed * Time.deltaTime);
        }
    }

    public void StopMovingPaths()
    {
        movingEnabled = false;
    }
}
