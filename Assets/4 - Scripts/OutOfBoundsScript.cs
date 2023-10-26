using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfBoundsScript : MonoBehaviour
{
    private CueBallScript cueBallInstance;
    private PlayerCamScript playerCamInstance;
    private PlayerScript cueStickInstance;

    private void Awake()
    {
        cueBallInstance = GameObject.Find("Cue Ball").GetComponent<CueBallScript>();
        cueStickInstance = GameObject.Find("Pool Cue").GetComponent<PlayerScript>();
        playerCamInstance = GameObject.Find("Player Camera").GetComponent<PlayerCamScript>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Cue Ball"))
        {
            cueBallInstance.ResetCuePosition();            
            cueStickInstance.CueStickFollowCue();
            playerCamInstance.CameraFollowCue();
        }
    }

}
