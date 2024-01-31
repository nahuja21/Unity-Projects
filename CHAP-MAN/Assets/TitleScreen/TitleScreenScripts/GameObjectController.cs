using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectController : MonoBehaviour
{
    // Reference to the game object you want to show/hide
    public GameObject targetGameObject;

    public bool startHidden;

    void Start(){
      if (startHidden == true){
        targetGameObject.SetActive(false);
      }
    }

    // Method to hide the game object
    public void HideGameObject()
    {
        if (targetGameObject != null)
        {
            targetGameObject.SetActive(false);
        }
    }

    // Method to show the game object
    public void ShowGameObject()
    {
        if (targetGameObject != null)
        {
            targetGameObject.SetActive(true);
        }
    }
}
