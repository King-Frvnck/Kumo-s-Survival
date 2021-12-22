using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    public bool isPlayerPresentByDefault = false;

    public static SceneManagerScript instance;

    private void Awake()
    {
      
      if(instance != null)
      {
        Debug.LogWarning("Il y'a plus d'une instance de SceneManagerScript dans la scène");
        return;
      }

      instance = this;
    }
}
