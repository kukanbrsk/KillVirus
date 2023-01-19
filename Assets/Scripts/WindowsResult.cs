using UnityEngine;
using UnityEngine.SceneManagement;

public class WindowsResult : MonoBehaviour
{

    [SerializeField] private GameObject pauseMenu;

   
    public void Menu()
    {
        SceneManager.LoadScene(0);

    }
    public void Restart ()
    {
        SceneManager.LoadScene(1);
    }


    public void OnPause()
  {
          Time.timeScale = 0;
          pauseMenu.SetActive(true);
      
  }

  public void Continue()
  {
      Time.timeScale = 1;
      pauseMenu.SetActive(false);
  }

}
