using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public Transform target;
    public float t;
    public GameObject skull;
    public Dialogue dialogue;

    private Vector3 scaleChange;

    void Awake()
    {
        scaleChange = new Vector3(0.02f, 0.02f, 0.02f);
    }
    IEnumerator ExampleCoroutine()
    {

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3);
        Vector2 a = transform.position;
        Vector2 b = target.position;
        transform.position = Vector2.Lerp(a, b, t);

        if (skull.transform.localScale.y < 2.5f )
        {
            skull.transform.localScale += scaleChange;

        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(ExampleCoroutine());

        
    }
}
