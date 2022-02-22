using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;

    float xMin;
    float xMax;
    float yMin;
    float yMax;

    [SerializeField] float padding = 0f;
    Animator animator;
    private bool isHitted = false;

    public GameObject deathCanvas;

    private void Awake()
    {
        deathCanvas.SetActive(false);
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        SetUpMoveBoundaries();
        
    }
    // Update is called once per frame
    void Update()
    {
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        var deltaY = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;

        var newXPos = Mathf.Clamp(transform.position.x + deltaX, xMin, xMax); //current position + new position
        var newYPos = Mathf.Clamp(transform.position.y + deltaY, yMin, yMax); //current position + new position

        transform.position = new Vector2(newXPos, newYPos);
        if (GetComponent<Health>().health <= 0)
        {
            animator.SetTrigger("Death"); //play hit animation

            deathCanvas.SetActive(true);
            FindObjectOfType<FirePattern1>().GameStarted = false;

        }

    }


    private void SetUpMoveBoundaries()
    {
        Camera gameCamera = Camera.main;
        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            if (isHitted)
                return;
            if(GetComponent<Health>().health <= 0)
            {

                FindObjectOfType<PlayAudio>().StopMusic();
                animator.SetTrigger("Death"); //play hit animation

                deathCanvas.SetActive(true);
                FindObjectOfType<FirePattern1>().GameStarted = false;

            }
            
            GetComponent<Health>().health--;
           
            StartCoroutine(HitWait());


        }
        if (collision.CompareTag("Health"))
        {

            GetComponent<Health>().AddHealth();
            Destroy(collision.gameObject);
        }
    }

    private IEnumerator HitWait()
    {
        isHitted = true;
        animator.SetTrigger("Hurt"); //play hit animation
        yield return new WaitForSeconds(2f); //invul time

        isHitted = false;

    }
}
