using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private int score;
    private float speed;
    private float gravity;
    private Vector3 moveDirection;

    public Transform target;
    public Text scoreText;

    // Target position
    public static float targetY = 0.0f;
    public static float targetZ = 0.0f;

    // Use this for initialization
    void Start()
    {
        score = 0;
        speed = 6.0f;
        gravity = 20.0f;

        scoreText.text = score.ToString();
        moveDirection = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        // See to the target
        transform.LookAt(target);
        targetZ = transform.position.z;
        targetY = transform.position.y;

        CharacterController controller = GetComponent<CharacterController>();

        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }

    private void OnTriggerExit(Collider other)
    {
        // Score count
        if (other.CompareTag("Tower"))
        {
            score += 2;            
        } else if (other.CompareTag("SlideObstacle"))
        {
            score += 4;
        }

        scoreText.text = score.ToString();
    }
}
