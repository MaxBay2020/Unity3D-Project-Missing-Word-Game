using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;

    //private GameObject[] words;
    public List<GameObject> words;
    //private List<string> wordsFilled = new List<string>();
    private string wordsFilled;
    private List<string> answers = new List<string>();
    private int index;
    public GameObject result_panel;
    private int totalCorrect;

    //the grey background image
    [SerializeField]
    public GameObject bgGrey;
    

    private void Start()
    {
        _instance = this;
        foreach (var word in words)
        {
            answers.Add(word.transform.Find("answer").GetComponent<Text>().text);
            
        }

    }


    public void FillWordsWithVowel(string vowel)
    {
        // fill all the words with the vowel
        //foreach (var word in words)
        //{
        //    //Debug.Log(word);
        //    word.transform.Find("Label_word").GetComponent<Text>().text
        //        = word.transform.Find("Label_word").GetComponent<Text>().text.Replace("_", vowel);

        //    wordsFilled.Add(word.transform.Find("Label_word").GetComponent<Text>().text);
        //}

        words[index].transform.Find("Label_word").GetComponent<Text>().text
            = words[index].transform.Find("Label_word").GetComponent<Text>().text.Replace("_", vowel);

        //wordsFilled.Add(words[index].transform.Find("Label_word").GetComponent<Text>().text);
        //get the filled word
        wordsFilled = words[index].transform.Find("Label_word").GetComponent<Text>().text;

        // play alphabet clip based on the word filled
        StartCoroutine(AlphabetClipPlay(wordsFilled));
    }

    /// <summary>
    /// coroutine: play alphabet sound one by one
    /// </summary>
    /// <param name="wordsFilled"></param>
    /// <returns></returns>
    IEnumerator AlphabetClipPlay(string wordsFilled)
    {
        char[] alphabets = wordsFilled.ToCharArray();
        foreach (char alphabet in alphabets)
        {
            foreach (AudioClip alphabetClip in SoundManager._instance.alphabetClips)
            {
                if (alphabetClip.name == alphabet.ToString())
                {
                    yield return new WaitForSeconds(alphabetClip.length);
                    SoundManager._instance.AlphabetSoundPlay(alphabetClip);
                    
                }
                    
            }
        }
    }


    /// <summary>
    /// when the correct button clicked, what is going to happen
    /// </summary>
    public void CorrectButtonClick()
    {
        //Debug.Log($"answers: {answers[index]}=========my word: {wordsFilled}");
        //whether the answer is correct
        if (index > words.Count)
            return;

        if (answers[index].Contains(wordsFilled))
        {
            //Debug.Log("correct!!!");
            SoundManager._instance.CorrectSoundPlay();
            totalCorrect++;
        }
        else
        {
            //Debug.Log($"answers: {answers[index]}=========my word: {wordsFilled}");

            //Debug.Log("wrong!!!");
            SoundManager._instance.WrongSoundPlay();
        }
        ShowResult();

        // move the index to the next
        index++;

        // hide the current, display the next
        for (int i = 0; i < words.Count; i++)
        {
            words[i].SetActive(i == index);
        }

        
    }

    /// <summary>
    /// when the wrong button clicked, what is going to happen
    /// </summary>
    public void WrongButtonClick()
    {
        if (index > words.Count)
            return;

        //whether the answer is correct
        if (answers[index].Contains(wordsFilled))
        {
            //Debug.Log($"answers: {answers[index]}=========my word: {wordsFilled}");

            //Debug.Log("wrong!!!");
            SoundManager._instance.WrongSoundPlay();
        }
        else
        {
            //Debug.Log($"answers: {answers[index]}=========my word: {wordsFilled}");

            //Debug.Log("correct!!!");
            SoundManager._instance.CorrectSoundPlay();
            totalCorrect++;
        }
        ShowResult();

        index++;

        // hide the current, display the next
        for (int i = 0; i < words.Count; i++)
        {
            words[i].SetActive(i == index);
        }

        
    }

    /// <summary>
    /// when all words are done, show the result
    /// </summary>
    private void ShowResult()
    {
        if (index >= words.Count - 1)
        {
            index = words.Count - 1;
            // display result panel
            result_panel.transform.DOLocalMove(new Vector3(0, this.transform.position.y+58, 0), 2f).SetEase(Ease.InOutBack);
            // play sound
            SoundManager._instance.CongradsSoundPlay();
            result_panel.transform.Find("total correct").GetComponent<Text>().text = totalCorrect.ToString();
            //cover the screen with the grey background image
            bgGrey.SetActive(true);
            return;
        }
    }

    /// <summary>
    /// when the restart button clicked, reload this scene
    /// </summary>
    public void RestartButtonClick()
    {
        SceneManager.LoadScene(1);  
    }
}
