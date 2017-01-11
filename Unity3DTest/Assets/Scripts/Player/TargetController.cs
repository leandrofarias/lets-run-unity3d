using UnityEngine;

public class TargetController : MonoBehaviour
{
    private const float OFFSET_Y = 0.45f;
    private const float OFFSET_Z = 20.0f;
    private const float MAX_POSITION_X = 20.0f;
    private SwipeGestureDetector swipeGestureDetector;

    // Use this for initialization
    void Start()
    {
        transform.position = new Vector3(0, transform.position.y, transform.position.z);
        swipeGestureDetector = new SwipeGestureDetector();
    }

    // Update is called once per frame
    void Update()
    {
        // Always front of the player
        float newY = PlayerController.targetY + OFFSET_Y;
        float newZ = PlayerController.targetZ + OFFSET_Z;
        transform.position = new Vector3(transform.position.x, newY, newZ);

        SwipeGestureDirection swipeGestureDirection = swipeGestureDetector.getSwipeGestureDirection(Input.touches);

        if (swipeGestureDirection == SwipeGestureDirection.Left)
        {
            // Go to the left
            if (transform.position.x == MAX_POSITION_X)
            {
                transform.position = new Vector3(0, transform.position.y, transform.position.z);
            }
            else if (transform.position.x == 0)
            {
                transform.position = new Vector3(-MAX_POSITION_X, transform.position.y, transform.position.z);
            }
        }
        else if (swipeGestureDirection == SwipeGestureDirection.Right)
        {
            // Go to the right
            if (transform.position.x == -MAX_POSITION_X)
            {
                transform.position = new Vector3(0, transform.position.y, transform.position.z);
            }
            else if (transform.position.x == 0)
            {
                transform.position = new Vector3(MAX_POSITION_X, transform.position.y, transform.position.z);
            }
        }
    }
}
