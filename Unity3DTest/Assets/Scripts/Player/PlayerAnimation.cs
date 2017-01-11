using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private static Animator animator;
    private SwipeGestureDetector swipeGestureDetector;

    // Animation triggers
    private static int turnRight;
    private static int turnLeft;
    private static int slide;
    private static int runSpeed;

    private static float speed;
    private bool slideStarted;

    public static bool isRunning;
    public static bool isPlayerDead;

    // Use this for initialization
    void Start()
    {
        animator = GetComponent<Animator>();
        swipeGestureDetector = new SwipeGestureDetector();
        turnRight = Animator.StringToHash("GoRight");
        turnLeft = Animator.StringToHash("GoLeft");
        slide = Animator.StringToHash("Slide");
        runSpeed = Animator.StringToHash("RunSpeed");
        isRunning = false;
        isPlayerDead = false;
        speed = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        Physics.gravity = new Vector3(0, -500.0f, 0);

        SwipeGestureDirection swipeGestureDirection = swipeGestureDetector.getSwipeGestureDirection(Input.touches);

        if (swipeGestureDirection == SwipeGestureDirection.Left && transform.position.x >= 0)
        {
            // Go to the left
            animator.SetTrigger(turnLeft);
        }
        else if (swipeGestureDirection == SwipeGestureDirection.Right && transform.position.x <= 0)
        {
            // Go to the right
            animator.SetTrigger(turnRight);
        }
        else if (swipeGestureDirection == SwipeGestureDirection.Down)
        {
            // Slide
            slideStarted = true;
            animator.SetTrigger(slide);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("SlideObstacle") && slideStarted)
        {
            // When the crossbar is detected and the sliding action is already activated, the 'Sliding' animation is executed.
            animator.SetFloat("Sliding", 1);
        }
        else if (other.CompareTag("DeathSensor") && !slideStarted)
        {
            // If the player does not trigger the sliding action on time, he is considered dead.
            isRunning = false;
            isPlayerDead = true;
            animator.enabled = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // When sliding completely under the obstacle, slide animation is stopped.
        if (other.CompareTag("SlideObstacle"))
        {
            slideStarted = false;
            animator.SetFloat("Sliding", 0);
        }
    }

    // Start of the game.
    public static void Run()
    {
        isRunning = true;
        animator.SetFloat("RunningValue", 1.0f);
    }

    // Increases player speed.
    public static void IncreasePlayerSpeed()
    {
        speed += 0.2f;
        animator.SetFloat("RunSpeed", speed);
    }
}
