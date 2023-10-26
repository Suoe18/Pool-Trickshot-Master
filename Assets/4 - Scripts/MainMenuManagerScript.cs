using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject helpPanelUI;

    [SerializeField] private Button playButton;
    [SerializeField] private Button helpButton;


    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SetButtonAsActive();
        helpPanelUI.SetActive(false);
    }     

    public void ClickedPlayButton()
    {
        DisabbleButton();
        SceneManager.LoadSceneAsync("FirstStage");        
    }

    public void ClickedHelpButton()
    {
        DisabbleButton();
        helpPanelUI.SetActive(true);
    }

    public void ExitHelpPanel()
    {
        helpPanelUI.SetActive(false);
        SetButtonAsActive();
    }

    private void DisabbleButton()
    {
        playButton.interactable = false;
        helpButton.interactable = false;
    }

    private void SetButtonAsActive()
    {
        playButton.interactable = true;
        helpButton.interactable = true;
    }
}
