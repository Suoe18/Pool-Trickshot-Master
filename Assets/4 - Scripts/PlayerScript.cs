using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    PlayerCamScript playerCamInstance;
    [SerializeField] public GameObject cueStickGO;    
    [SerializeField] private Transform cueBallPosition;
    [SerializeField] private GameObject pausePanel;
           
    public bool playerStrike;    

    private void Awake()
    {
        playerCamInstance = GameObject.Find("Player Camera").GetComponent<PlayerCamScript>();      
    }

    void Start()
    {
        
    }
    
    void Update()
    {                                  
        if(Input.GetKey(KeyCode.Escape) && !playerStrike)
        {
            if(!playerCamInstance.isGamePaused)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                pausePanel.SetActive(true);
                playerCamInstance.isGamePaused = true;
            }            
        }
    }

    private void FixedUpdate()
    {
        if(playerCamInstance.cueStickIsReleased)
        {            
            cueStickGO.transform.position = Vector3.MoveTowards(cueStickGO.transform.position, cueBallPosition.transform.position, 1000 * Time.deltaTime);
        }                    
    }
    

    public void CueStickFollowCue()
    {
        transform.position = cueBallPosition.position - transform.forward * 115;
        transform.LookAt(cueBallPosition);       
    }

   
}
