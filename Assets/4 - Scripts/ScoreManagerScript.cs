using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManagerScript : MonoBehaviour
{
    private LevelManagerScript levelManagerInstance;    


    private void Awake()
    {
        levelManagerInstance = GameObject.Find("LevelManager").GetComponent<LevelManagerScript>();        
    }


    void Update()
    {
        if(levelManagerInstance.isPlaying)
        {
            if (levelManagerInstance.levelCounter == 1)
            {
                if (levelManagerInstance.score >= 6)
                {
                    levelManagerInstance.levelCounter++;
                    levelManagerInstance.isPlaying = false;
                    levelManagerInstance.score = 0;
                }
            }
            if (levelManagerInstance.levelCounter == 2)
            {
                if (levelManagerInstance.score >= 9)
                {
                    levelManagerInstance.levelCounter++;
                    levelManagerInstance.isPlaying = false;
                    levelManagerInstance.score = 0;
                }
            }
            if (levelManagerInstance.levelCounter == 3)
            {
                if (levelManagerInstance.score >= 15)
                {
                    levelManagerInstance.levelCounter++;
                    levelManagerInstance.isPlaying = false;
                    levelManagerInstance.score = 0;
                }
            }
        }       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Pool Ball"))
        {
            levelManagerInstance.score += 1;
            Debug.Log("score: " + levelManagerInstance.score);
            Destroy(collision.gameObject);
        }
    }
}
