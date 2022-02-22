using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    private float rotateSpeed = 10f;
    void Update()
    {
        // Spin the object around the target at 20 degrees/second.
        transform.RotateAround(Vector3.zero, Vector3.forward, rotateSpeed * Time.deltaTime);
        GetComponent<SpriteRenderer>().color = new Color(0f, 0f, 0f, 1f);
        Camera.main.backgroundColor = Color.white;

        Debug.Log(transform.rotation);
        //rotateSpeed += 2f;
    }
}
