using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    SceneLoader sceneLoader;
    
    [SerializeField] int breakableblocks;

    private void Start()
    {
        sceneLoader = FindObjectOfType<SceneLoader>();
    }

    public void BlockDestroyed()
    {
        breakableblocks--;

        if(breakableblocks <= 0)
        {
            sceneLoader.LoadNextScene();
        }
    }

    public void CountBreakableBlocks()
    {
        breakableblocks++;
    }
}
