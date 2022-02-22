using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    [SerializeField] public float moveSpeed;
    private Vector2 moveDirection;


    private void OnEnable()
    {
        Invoke("Destroy", 8f);
    }
    void Start()
    {
        //moveSpeed = 10f;  
    }

    void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);

    }
    public void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }
    
}
