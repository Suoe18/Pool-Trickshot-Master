using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManagerScript : MonoBehaviour
{
    [SerializeField] GameObject titleUIPanel;
    [SerializeField] GameObject levelOnePanel;
    [SerializeField] GameObject levelTwoPanel;
    [SerializeField] GameObject levelThreePanel;
    [SerializeField] GameObject WinnerPanel;
    
    private BallPatternSpawner ballSpawnerInstance;
    private PlayerCamScript playerCamInstance;
    private CueBallScript cueBallInstance;    
    private PlayerScript cueStickInstance;

    public int levelCounter;
    public bool isPlaying;

    public float score;

    private void Awake()
    {        
        ballSpawnerInstance = GameObject.Find("SpawnManager").GetComponent<BallPatternSpawner>();
        playerCamInstance = GameObject.Find("Player Camera").GetComponent<PlayerCamScript>();
        cueBallInstance = GameObject.Find("Cue Ball").GetComponent<CueBallScript>();
        cueStickInstance = GameObject.Find("Pool Cue").GetComponent<PlayerScript>();
    }

    private void Start()
    {
        levelCounter = 1;
        score = 0;
    }

    void Update()
    {
        if(!playerCamInstance.isGamePaused && !isPlaying)
        {            
            switch (levelCounter)
            {
                case 1:
                    StartCoroutine(levelOneShowBanner());
                    ballSpawnerInstance.SpawnTriangle();
                    break;
                case 2:
                    StartCoroutine(levelTwoShowBanner());
                    ballSpawnerInstance.SpawnDiamond();
                    break;
                case 3:
                    StartCoroutine(levelThreeShowBanner());
                    ballSpawnerInstance.SpawnDiamond();
                    break;
                case 4:
                    StartCoroutine(WinnerShowBanner());
                    break;
            }
        }
    }

    IEnumerator levelOneShowBanner()
    {
        playerCamInstance.isGamePaused = true;
        ResetView();
        yield return new WaitForSeconds(1);        
        titleUIPanel.SetActive(true);
        levelOnePanel.SetActive(true);        

        yield return new WaitForSeconds(1);

        titleUIPanel.SetActive(false);
        levelOnePanel.SetActive(false);
        isPlaying = true;
        playerCamInstance.isGamePaused = false;
    }

    IEnumerator levelTwoShowBanner()
    {
        playerCamInstance.isGamePaused = true;
        ResetView();
        yield return new WaitForSeconds(2);

        titleUIPanel.SetActive(true);
        levelTwoPanel.SetActive(true);        

        yield return new WaitForSeconds(3);

        titleUIPanel.SetActive(false);
        levelTwoPanel.SetActive(false);
        isPlaying = true;
        playerCamInstance.isGamePaused = false;
    }

    IEnumerator levelThreeShowBanner()
    {
        playerCamInstance.isGamePaused = true;
        ResetView();
        yield return new WaitForSeconds(2);

        titleUIPanel.SetActive(true);
        levelThreePanel.SetActive(true);
        
        yield return new WaitForSeconds(3);

        titleUIPanel.SetActive(false);
        levelThreePanel.SetActive(false);
        isPlaying = true;
        playerCamInstance.isGamePaused = false;
    }

    IEnumerator WinnerShowBanner()
    {
        playerCamInstance.isGamePaused = true;
        WinnerPanel.SetActive(true);
        yield return new WaitForSeconds(5);

        SceneManager.LoadSceneAsync("MainMenu");
    }


    private void ResetView()
    {
        cueBallInstance.ResetCuePosition();
        cueStickInstance.CueStickFollowCue();
        playerCamInstance.CameraFollowCue();
    }
}
