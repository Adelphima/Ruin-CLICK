using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Slider timerSlider;
    public float gameTime;
    private bool stopTimer;
   

    private void Start()
    {
       
        timerSlider.value = 100;

        InvokeRepeating("IncramentTimer", 0, 0.005f);
    }
    private void IncramentTimer()
    {
        timerSlider.value = timerSlider.value - 0.15f;


    }

    private void Update()
    {
 

        if (timerSlider.value <= 0)
        {
            stopTimer = true;

           

        }
       

    }

    


}




