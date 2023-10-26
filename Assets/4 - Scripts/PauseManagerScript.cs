using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject pausePanel;
    PlayerCamScript playerCamInstance;
    private void Awake()
    {
        playerCamInstance = GameObject.Find("Player Camera").GetComponent<PlayerCamScript>();
    }

    void Start()
    {
        pausePanel.SetActive(false);
    }
    
    void Update()
    {
        
    }

    public void ResumeButtonClicked()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pausePanel.SetActive(false);
        Invoke("Unpause", 2);
    }

    private void Unpause()
    {
        playerCamInstance.isGamePaused = false;
    }

    public void MenuButtonClicked()
    {
        SceneManager.LoadSceneAsync("MainMenu");
    }
}
