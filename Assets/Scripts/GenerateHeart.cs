using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHeart : MonoBehaviour
{
    public GameObject heartObject;
    private float minX = -8;
    private float maxX = 8;
    private float minY = -5;
    private float maxY = 5;
    private int max = 10;
    public int curHeart = 0;

    bool called = false;
    void Start()
    {
    }

    private void Update()
    {
        if (GetComponent<FirePattern1>().GameStarted == true && called == false)
        {

            StartCoroutine(spawn());
            called = true;
        }
    }
    IEnumerator spawn() {


            for (var curHeart = 0; curHeart < max; curHeart++) {
                yield return new WaitForSeconds(6);
                var theNewPos = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), 0);
                GameObject heart = Instantiate(heartObject);
                heart.transform.position = theNewPos;
            }
        
     }
}
