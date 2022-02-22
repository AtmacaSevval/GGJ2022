using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePattern5 : MonoBehaviour
{
    public GameObject line;

    private float rotateSpeed = 10f;

    private bool calledNext = false;
    private void Start()
    {
        line.SetActive(true);
    }
    void Update()
    {
        if (!GetComponent<FirePattern1>().GameStarted)
            return;
        if (Time.deltaTime > 0.5 && calledNext == false)
        {
            var scriptName = GetComponent<GenerateRandomPattern>().chooseAPattern(5);
            GetComponent<GenerateRandomPattern>().EnableComp(scriptName);
            this.enabled = false;
            line.SetActive(false);
            calledNext = true;
            return;
        }
        line.transform.RotateAround(Vector3.zero, Vector3.forward, rotateSpeed * Time.deltaTime);
    }
}
