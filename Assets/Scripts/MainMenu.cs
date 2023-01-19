using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Difficulty current;
   public void PlayGame(Difficulty difficulty)
   {
       current.virusCount = difficulty.virusCount;
       current.spawnInterval = difficulty.spawnInterval;
       current.baseScale = difficulty.baseScale;
       current.baseSpeed = difficulty.baseSpeed;
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
