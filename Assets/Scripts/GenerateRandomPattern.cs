using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateRandomPattern : MonoBehaviour
{

    private float num;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void chooseARandom(int scriptNum)
    {
        var guessnum = Random.Range(1, 5);
        if (guessnum != scriptNum)
        {

            num = guessnum; ;
        }
        else
        {
            chooseARandom(scriptNum);
        }
    }
    public string chooseAPattern(int scriptNum)
    {

        chooseARandom(scriptNum);
        switch (num)
        {
            case 4:
                return "FirePattern4";
            case 3:
                return "FirePattern3";
            case 2:
                return "FirePattern2";
            case 1:
                return "FirePattern1";
        }
        return null;
    }

    public void EnableComp(string scriptName)
        
    {
        if (scriptName == "FirePattern4")
        {

            GetComponent<FirePattern4>().enabled = true;
        }
        else if (scriptName == "FirePattern3")
        {

            GetComponent<FirePattern3>().enabled = true;
        }
        else if (scriptName == "FirePattern2")
        {

            GetComponent<FirePattern2>().enabled = true;
        }
        else if (scriptName == "FirePattern1")
        {

            GetComponent<FirePattern1>().enabled = true;
        }
    }

}
