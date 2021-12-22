using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoadScript : MonoBehaviour
{
    public GameObject[] objects;

    public static DontDestroyOnLoadScript instance;

    private void Awake()
    {
      
      if(instance != null)
      {
        Debug.LogWarning("Il y'a plus d'une instance de DontDestroyOnLoadScript dans la scène");
        return;
      }
      instance = this;
      
       foreach (var element in objects)
     {
       DontDestroyOnLoad(element);
     }
    }

     public void RemoveFromDontDestroyOnLoad()
    {
        foreach (var element in objects)
     {
       SceneManager.MoveGameObjectToScene(element, SceneManager.GetActiveScene());
     }
    }
}
