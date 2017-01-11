using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Class that controls the game life cycle.
 */
public class GameLifeCycleController : MonoBehaviour
{
    public void StartGame()
    {
        PlayerAnimation.Run();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
