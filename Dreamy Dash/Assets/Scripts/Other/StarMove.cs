using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarMove : MonoBehaviour
{
    public float moveSpeed = 17f;
    private Vector3 targetPosition;

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

    public void SetTargetPosition(Vector3 position)
    {
        targetPosition = position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PlayerBubble")
        {
            Destroy(gameObject);
        }
    }
}
