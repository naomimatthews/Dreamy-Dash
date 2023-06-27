using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private CharacterController controller;

    // Movement variables.
    public static float moveSpeed;
    private Vector3 direction;

    public static int starCounter;

    private int desiredLane = 1; // 0 = left, 1 = middle, 2 = right.
    public float laneDistance = 10f; // The distance between two lanes.

    public float jumpForce;
    public float gravity = -20f;

    public TextMeshProUGUI starCountText;

    public PathMover pathMover;

    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        controller = GetComponent<CharacterController>();
        starCounter = 0;
        starCountText.text = starCounter.ToString();

        animator.SetBool("isRun", true);
    }

    private void Update()
    {
        direction.z = moveSpeed;

        if (controller.isGrounded)
        {
            animator.SetBool("isRun", true);
            direction.y = -1f;

            if (SwipeManager.swipeUp)
            {
                Jump();
            }
        }
        else
        {
            direction.y += gravity * Time.deltaTime;
        }

        if (SwipeManager.swipeRight)
        {
            desiredLane++;
            if (desiredLane == 3)
            {
                desiredLane = 2;
            }
        }

        if (SwipeManager.swipeLeft)
        {
            desiredLane--;
            if (desiredLane == -1)
            {
                desiredLane = 0;
            }
        }

        // Calculate where the player should be in the future.
        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }
        else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        if (transform.position == targetPosition)
        {
            return;
        }

        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25f * Time.deltaTime;

        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
        {
            controller.Move(moveDir);
        }
        else
        {
            controller.Move(diff);
        }
    }

    private void FixedUpdate()
    {
        controller.Move(direction * Time.fixedDeltaTime);
    }

    private void Jump()
    {
        direction.y = jumpForce;
        animator.Play("jump");
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.CompareTag("Obstacle"))
        {
            pathMover.StopMovingPaths();

            animator.Play("sad");

            AnalyticsResult analyticsResult = Analytics.CustomEvent("Distance" + DistanceScore.distance);
            Debug.Log("analyticsResult: " + analyticsResult);

            PlayerManager.gameOver = true; // Set game over flag
        }
    }

    private void OnTriggerEnter(Collider other)
    {   
        if (other.CompareTag("Star"))
        {
            starCounter++;
            UpdateStarCountText();
            Destroy(other.gameObject);

            // Save data.
            int totalStars = PlayerPrefs.GetInt("Stars", 0);
            totalStars++;
            PlayerPrefs.SetInt("Stars", totalStars);
            PlayerPrefs.Save();
        }
    }

    private void UpdateStarCountText()
    {
        starCountText.text = starCounter.ToString();
    }
}
