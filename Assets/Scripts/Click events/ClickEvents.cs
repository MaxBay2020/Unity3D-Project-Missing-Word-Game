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

    // index of tutorial panels
    private int index;

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
        SceneManager.LoadScene(0);
    }
}
