using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolBallScript : MonoBehaviour
{
    private BallPatternSpawner ballPatternInstance;    
    private Rigidbody thisBallRB;

    private void Awake()
    {
        ballPatternInstance = GameObject.Find("SpawnManager").GetComponent<BallPatternSpawner>();
    }

    void Start()
    {
        thisBallRB = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cue Ball"))
        {
            thisBallRB.AddForce(Camera.main.transform.forward * 200, ForceMode.Force);           
        }
        if (collision.gameObject.CompareTag("Floor"))
        {
            transform.position = ballPatternInstance.spawnPoint.transform.position;
        }
        if (collision.gameObject.CompareTag("Outbound"))
        {
            transform.position = ballPatternInstance.spawnPoint.transform.position;
        }
    }
}
