using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamScript : MonoBehaviour
{
    [SerializeField] private Transform cueBall;
    [SerializeField] private Transform cameraPos;

    public float sensX;    

    public Transform orientation;

    public bool cueStickIsReleased;
    public float forceGathered;
    private float defaultDistFromCueBall;
    private float maxClampDist = 50;
    private float minClampDist = 120;

    public bool isGamePaused;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        defaultDistFromCueBall = Vector3.Distance(cueBall.position, transform.position);
    }

    
    private void Update()
    {
        if(!isGamePaused)
        {
            float x = 0.0f;
            float y = 0f;
            if (Input.GetMouseButton(0))
            {
                x = Input.GetAxis("Mouse X") - Input.GetAxis("Horizontal");
                y = Input.GetAxis("Mouse Y");

                var newPosition = orientation.transform.position + orientation.transform.forward * y;                
                forceGathered = Vector3.Distance(cueBall.position, newPosition);

                if ((forceGathered < defaultDistFromCueBall + maxClampDist) &&
                    forceGathered > defaultDistFromCueBall)
                {

                    orientation.transform.position = newPosition;
                }

                orientation.transform.RotateAround(cueBall.position, Vector3.up, x * sensX * Time.deltaTime);
                transform.RotateAround(cueBall.position, Vector3.up, x * sensX * Time.deltaTime);

            }
            else if (Input.GetMouseButtonUp(0))
            {
                cueStickIsReleased = true;
            }
        }                        
    }

    public  void CameraFollowCue()
    {
        transform.position = new Vector3(cameraPos.position.x, cameraPos.position.y, cameraPos.position.z);
    }
}
