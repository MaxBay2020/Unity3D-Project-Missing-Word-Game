using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Roll_dice_button_controller : MonoBehaviour
{
    // get the dice_image gameobject;
    public GameObject dice_image, word_panel;

    // get the images of the button;
    public Texture roll_button_image, stop_button_image;

    // flag: if the dice is rolling;
    private bool isRolling;

    public GameObject dice;

    /// <summary>
    /// when click 'roll the dice button', trigger this function;
    /// </summary>
    public void Roll_dice_and_stop_button()
    {
        if(isRolling)
        {
            //if the dice is rolling, click to stop rolling
            // 1. change the image to 'stop_button'
            // 2. and enable the animator component;
            // 3. change isRolling to false;
            // 4. get the vowel
            // 5. stop playing dice rolling sound
            this.GetComponent<RawImage>().texture = roll_button_image;
            dice_image.GetComponent<Animator>().enabled = false;
            isRolling = false;
            //Debug.Log(dice_image.GetComponent<RawImage>().texture.name);
            string vowel = dice_image.GetComponent<RawImage>().texture.name;
            // call a coroutine
            //StartCoroutine(ShowPanel(vowel));

            // set the vowel
            GameManager._instance.FillWordsWithVowel(vowel);

            dice.GetComponent<AudioSource>().Stop();

        }
        else
        {
            //if the dice is stopped, click to roll the dice
            // 1. change the image to 'roll_button_image'
            // 2. and disable the animator component;
            // 3. change isRolling to true;
            // 4. play dice rolling sound
            this.GetComponent<RawImage>().texture = stop_button_image;
            dice_image.GetComponent<Animator>().enabled = true;
            isRolling = true;
            dice.GetComponent<AudioSource>().Play();
        }


    }

    /// <summary>
    /// when roll dice button clicked, roll the dice
    /// </summary>
    public void RollDiceButtonClick()
    {
        // 1. disable the button
        this.GetComponent<Button>().enabled = false;
        // 2. roll the dice
        dice_image.GetComponent<Animator>().enabled = true;

        // 3. play the rolling dice sound
        dice.GetComponent<AudioSource>().Play();

        // call a coroutine
        StartCoroutine(StopRollingDice(Random.Range(1.5f, 2.5f)));
        
    }

    IEnumerator StopRollingDice(float second)
    {
        yield return new WaitForSeconds(second);
        // 4. after certain seconds, stop the dice
        dice_image.GetComponent<Animator>().enabled = false;
        // 5. get the vowel stopped
        string vowel = dice_image.GetComponent<RawImage>().texture.name;
        // 6. set the vowel
        GameManager._instance.FillWordsWithVowel(vowel);
        // 7. stop playing rolling dice sound
        dice.GetComponent<AudioSource>().Stop();
    }

    IEnumerator ShowPanel(string vowel)
    {

        //this.gameObject.GetComponent<Button>().enabled = false;
        yield return new WaitForSeconds(1.0f);

        // show background panel and words panel after certain seconds
        //bg_panel.SetActive(true);
        word_panel.SetActive(true);

        GameManager._instance.FillWordsWithVowel(vowel);
        
    }

    //private void Update()
    //{
    //    // get all toggles implement checkmark function
    //    GameObject[] toggles = GameObject.FindGameObjectsWithTag("toggles");

    //    for (int i = 0; i < toggles.Length; i++)
    //    {
    //        if (toggles[i].GetComponent<Toggle>().isOn)
    //        {
    //            GameObject[] answers = GameObject.FindGameObjectsWithTag("answer");
    //            GameObject[] blanks = GameObject.FindGameObjectsWithTag("fill");
    //            Debug.Log(answers[i].name.GetType());
    //            Debug.Log(blanks[i].GetComponent<Text>().text.GetType());
    //            Debug.Log(answers[i].name.CompareTo(blanks[i].GetComponent<Text>().text));


    //        }
    //    }
    //}

}
