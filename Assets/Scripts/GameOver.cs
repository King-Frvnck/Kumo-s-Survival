using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
  public GameObject gameOverUI;

   public static GameOver instance;

    private void Awake()
    {
      
      if(instance != null)
      {
        Debug.LogWarning("Il y'a plus d'une instance de GameOver dans la scène");
        return;
      }

      instance = this;
    }

  public void OnPlayerDeath()
  {
      gameOverUI.SetActive(true);
      if(SceneManagerScript.instance.isPlayerPresentByDefault)
      {
          DontDestroyOnLoadScript.instance.RemoveFromDontDestroyOnLoad();
      }
      
  }

  public void RetryButton()
  {
    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    gameOverUI.SetActive(false);
  }

   public void MainMenuButton()
  {

  }

  public void QuitButton()
  {
    Application.Quit();
  }
}
