using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StarsHandler : MonoBehaviour
{

    public GameObject[] stars;

    private int coinsCount;
    void Start()
    {
        coinsCount = GameObject.FindGameObjectsWithTag("coin").Length;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StarAchived()
    {
        float coinsLeft = GameObject.FindGameObjectsWithTag("coin").Length;
        float coinsCollected = coinsCount - coinsLeft;

        float percentage = coinsCollected / coinsCount * 100;
       
        if (percentage > 33 && percentage < 66)
        {
            stars[0].SetActive(true);
        } 
        else if (percentage > 66 && percentage < 70)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
        }
        else if( percentage > 71)
        {
            stars[0].SetActive(true);
            stars[1].SetActive(true);
            stars[2].SetActive(true);
        }
    }

   
}
