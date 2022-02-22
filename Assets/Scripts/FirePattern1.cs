using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePattern1 : MonoBehaviour
{
    private float angle = 0f;
    [SerializeField] float patternSpeed = 8f;
    private float loopTime = 0f;

    private bool called= false;
    public bool GameStarted = false;
    void Start()
    {
        InvokeRepeating("Fire", 3f, 0.01f);
    }

    private void Init()
    {
        angle = 0f;
        loopTime = 0;
        CancelInvoke();
        called = true;
    }

    private void Update()
    {
        if (called)
        {
            InvokeRepeating("Fire", 2f, 0.01f);
            called = false;
        }
    }
    void Fire()
    {
        if (GameStarted)
        {
            if (loopTime > 30)
            {
                var scriptName = GetComponent<GenerateRandomPattern>().chooseAPattern(1);
                GetComponent<GenerateRandomPattern>().EnableComp(scriptName);
                this.enabled = false;
                Init();
                return;
            }
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
            bul.GetComponent<Bullet>().moveSpeed = patternSpeed;

            angle += 5f;
            loopTime++;
        }
    }
}
