using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class loading : MonoBehaviour
{
    public void loadlevel(int sceneindex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneindex);
        
 
        StartCoroutine (LoadAsynchronously(sceneindex));

    
    }


    IEnumerator LoadAsynchronously (int sceneindex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneindex);
        while (!operation.isDone)
        {
            Debug.Log(operation.progress);

            yield return null;
        }
    }

}

