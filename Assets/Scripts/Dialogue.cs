using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[System.Serializable]
public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textDisplay;
    public string[] sentences;
    private int index;
    public float typingSpeed;

    public int index1 = 0;
    public GameObject continueButton;
    void Start()
    {

        StartCoroutine(Type());
    }


    void Update()
    {
        if(textDisplay.text == sentences[index])
        {
            continueButton.SetActive(true);
        }
        else
        {
            continueButton.SetActive(false);

        }
    }
    
    IEnumerator Type()
    {
        if(index1 == 0)
        {
            yield return new WaitForSeconds(4);
            index1++;
        }

        foreach (char letter in sentences[index].ToCharArray())
        {
            textDisplay.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
    public void NextSentence()
    {
        continueButton.SetActive(false);

        if (index < sentences.Length -1)
        {
            index++;
            textDisplay.text = "";
            StartCoroutine(Type());
        }
        else
        {
            textDisplay.text = "";
            continueButton.SetActive(false);
            FindObjectOfType<FirePattern1>().GameStarted = true;
        }
    }

}
