using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointCounter : MonoBehaviour
{
    [SerializeField] Scoremanager scoreManager;

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