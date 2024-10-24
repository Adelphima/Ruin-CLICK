using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCounter : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;

    private void Start()
    {
        StartCoroutine(CountPoints());
    }

    private IEnumerator CountPoints()
    {
        while(true)
        {
            scoreManager.Points += 5;

            yield return new WaitForSeconds(1);


        }


    }

  }