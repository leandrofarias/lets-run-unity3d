using UnityEngine;

public class ScenarioBlockGenerator : MonoBehaviour
{
    public Transform nextScenarioBlock;
    public GameObject previousScenarioBlock;
    
    private void OnTriggerEnter(Collider other)
    {
        // Collision detection with the character.
        if (other.CompareTag("Player"))
        {
            Vector3 newPosition = new Vector3(nextScenarioBlock.position.x, nextScenarioBlock.position.y, nextScenarioBlock.position.z + 375);
            
            // Instantiation of the new block.
            Transform newScenarioBlock = Instantiate(nextScenarioBlock, newPosition, nextScenarioBlock.rotation);
            ScenarioBlockGenerator scenarioBlockGenerator = newScenarioBlock.GetComponent<ScenarioBlockGenerator>();

            // If the previous block exists, it is destroyed.
            if (previousScenarioBlock != null)
            {
                Destroy(previousScenarioBlock);
                PlayerAnimation.IncreasePlayerSpeed();
            }

            // The current block is saved in the block script that has just been generated.
            if (scenarioBlockGenerator != null)
            {
                scenarioBlockGenerator.previousScenarioBlock = gameObject;
            }
        }
    }
}
