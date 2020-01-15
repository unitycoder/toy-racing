using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    public GameObject creditUI, mainUI;

    public void StartGame()
    {
        SceneManager.LoadScene("Scenes/TestTrack/TestTrack");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Credits()
    {
        mainUI.gameObject.SetActive(false);
        creditUI.gameObject.SetActive(true);
    }

    public void CreditsBack()
    {
        creditUI.gameObject.SetActive(false);
        mainUI.gameObject.SetActive(true);
    }
}
