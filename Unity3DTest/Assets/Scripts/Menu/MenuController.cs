using UnityEngine;

public class MenuController : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject startGameMenu;
    public GameObject score;

    // Use this for initialization
    void Start()
    {
        // Activates the start menu
        startGameMenu.SetActive(true);

        // Deactivates the score
        score.SetActive(false);

        // Deactivates the game over menu
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerAnimation.isRunning)
        {
            // Start of the game
            startGameMenu.SetActive(false);
            score.SetActive(true);
        }
        else if (PlayerAnimation.isPlayerDead)
        {
            // End of the game
            gameOverMenu.SetActive(true);
        }
    }
}
