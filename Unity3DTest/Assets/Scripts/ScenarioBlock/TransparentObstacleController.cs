using UnityEngine;

public class TransparentObstacleController : MonoBehaviour
{
    public Material normal;
    public Material transparent;

    // Use this for initialization
    void Start()
    {
        GetComponent<Renderer>().material = normal;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("MainCamera") && !PlayerAnimation.isPlayerDead)
        {
            GetComponent<Renderer>().material = transparent;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("MainCamera"))
        {
            GetComponent<Renderer>().material = normal;
        }
    }
}
