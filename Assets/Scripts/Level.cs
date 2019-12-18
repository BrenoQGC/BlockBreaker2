using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    //Config Parameters
   [SerializeField] int breakableBlocks;

   //cached reference
    SceneLoader sceneloader;

    private void Start()
    {
        sceneloader = FindObjectOfType<SceneLoader>();
    }
    public void CountBlocks()
    {
        breakableBlocks++;       
    } 

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            Debug.Log("called");
            sceneloader.LoadNextScene();
        }
    }
}
