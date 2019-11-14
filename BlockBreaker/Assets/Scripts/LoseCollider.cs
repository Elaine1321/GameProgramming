using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoseCollider : MonoBehaviour
{
    [SerializeField] SceneLoader SceneLoader;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        SceneLoader.LoadLevel("Gameover");
        
    }
   
}
