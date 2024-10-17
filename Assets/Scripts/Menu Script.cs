using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    //Load Next scene
    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    
    
        
    
    //Quiting the game
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Player Has Quit The Game");
    }
    
    
        
    
}
