using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CueBallScript : MonoBehaviour
{
    [SerializeField] private Transform cueInitialPos;
    private PlayerScript cueStickInstance;
    private PlayerCamScript playerCamInstance;    

    private Rigidbody cueBallRB;
    public bool playerTurnIsDone;

    

    private void Awake()
    {
        cueStickInstance = GameObject.Find("Pool Cue").GetComponent<PlayerScript>();
        playerCamInstance = GameObject.Find("Player Camera").GetComponent<PlayerCamScript>();        
    }

    void Start()
    {
        cueBallRB = GetComponent<Rigidbody>();        
    }
    
    void Update()
    {               
        
    }

    IEnumerator CueBallMovement()
    {
        playerTurnIsDone = false;

        cueStickInstance.gameObject.SetActive(false);                

        yield return new WaitForSeconds(6);

        playerCamInstance.cueStickIsReleased = false;
        playerTurnIsDone = true;        
        cueStickInstance.playerStrike = false;         
        cueStickInstance.CueStickFollowCue();
        cueStickInstance.gameObject.SetActive(true);
        playerCamInstance.CameraFollowCue();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Cue") && playerCamInstance.cueStickIsReleased)
        {
            cueBallRB.AddForce(Camera.main.transform.forward * 600 * playerCamInstance.forceGathered, ForceMode.Force);
            cueStickInstance.playerStrike = true;
            StartCoroutine(CueBallMovement());            
        }
        else if (other.CompareTag("TipCue") && playerCamInstance.cueStickIsReleased)
        {
            StartCoroutine(CueBallMovement());
            cueBallRB.AddForce(Camera.main.transform.forward * 600 * playerCamInstance.forceGathered, ForceMode.Force);
            cueStickInstance.playerStrike = true;            
        }
    }    



    public void ResetCuePosition()
    {
        transform.position = cueInitialPos.position;
    }
}
