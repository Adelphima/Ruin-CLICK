using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public float gameTime;
    private bool stopTimer;
    public Text gameOver;

   

    private void Start()
    {
        gameOver.fontSize = 200;
        timerSlider.value = 100;

        InvokeRepeating("IncramentTimer", 0, 0.005f);
    }
    private void IncramentTimer()
    {
        timerSlider.value = timerSlider.value - 0.15f;


    }
       
    public void addTime()
    {
        
        timerSlider.value = timerSlider.value + 50f;


    }

    private void Update()
    {



        if (timerSlider.value <= 0)
        {
            stopTimer = true;

            gameOver.fontSize = gameOver.fontSize = 36;

           
        }

       
       
        

    }

    


}




