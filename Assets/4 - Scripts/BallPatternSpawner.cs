using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPatternSpawner : MonoBehaviour
{
    [SerializeField] GameObject trianglePattern;
    [SerializeField] GameObject diamondPattern;
    [SerializeField] GameObject pyramidPattern;
    [SerializeField] public Transform spawnPoint;

    public void SpawnTriangle()
    {
        Instantiate(trianglePattern, spawnPoint.position, Quaternion.identity);
    }

    public void SpawnDiamond()
    {
        Instantiate(diamondPattern, spawnPoint.position, Quaternion.identity);
    }

    public void SpawnPyramid()
    {
        Instantiate(pyramidPattern, spawnPoint.position, Quaternion.identity);
    }
}
