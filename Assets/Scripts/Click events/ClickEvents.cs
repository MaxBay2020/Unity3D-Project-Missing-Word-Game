using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ClickEvents : MonoBehaviour
{
    [Header("Tutorial Panels")]
    public GameObject bgGrey;
    public GameObject[] tutorialPanels;
    public Texture soundMutedImage, soundUnmutedImage;
    public GameObject bgMusic;

    // index of tutorial panels
    private int index;

    // the flat of muted music
    private bool hasMusic = true;

    /// <summary>
    /// when start button clicked, load the main scene
    /// </summary>
    public void StartButtonClick()
    {
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// when question mark clicked, show the legend panel
    /// </summary>
    public void ShowTutorial()
    {
        //1. make the bg grey
        bgGrey.SetActive(true);

        //2. display the legeng panel
        tutorialPanels[index].SetActive(true);
    }

    /// <summary>
    /// when next page button clicked, show next tutorial page
    /// </summary>
    public void NextPageButtonClick()
    {
        index++;
        for (int i = 0; i < tutorialPanels.Length; i++)
        {
            //if(index!=i)
            tutorialPanels[i].SetActive(index == i);
        }
    }

    /// <summary>
    /// when finish button clicked, close tutorial window
    /// </summary>
    public void FinishButtonClick()
    {
        tutorialPanels[index].SetActive(false);
        bgGrey.SetActive(false);
    }

    /// <summary>
	/// when exit button clicked, return to the menu scene
	/// </summary>
    public void ExitButtonClick()
    {
        Application.Quit();
    }

    /// <summary>
    /// when mute button clicked, mute the bg music
    /// </summary>
    public void MuteButtonClicked()
    {
        if (hasMusic)
        {
            // 1. switch sprite to muted image
            bgMusic.GetComponent<RawImage>().texture = soundMutedImage;
            // 2. turn off music
            Camera.main.GetComponent<AudioSource>().mute = true;
        }
        else
        {
            // 1. switch sprite to unmuted image
            bgMusic.GetComponent<RawImage>().texture = soundUnmutedImage;
            // 2. turn on music
            Camera.main.GetComponent<AudioSource>().mute = false;
        }
        hasMusic = !hasMusic;
    }
}
