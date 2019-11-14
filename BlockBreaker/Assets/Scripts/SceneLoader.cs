using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
   //create a method tohat loads a scene
  public void LoadLevel (string sceneName)
  {
      SceneManager.LoadScene(sceneName);
  }

    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

   //create a method that quits the game
   public void QuitGame()
   {
       //works when running the game from EXE file
       //Application.Quit();

       //quits Unity Editor  
       UnityEditor.EditorApplication.isPlaying = false;
   }
}
