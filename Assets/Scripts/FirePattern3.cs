using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePattern3 : MonoBehaviour
{
    private float angle = 0f;

    private int armCount = 2;
    private int loopTime = 0;
    [SerializeField] float patternSpeed = 7f;

    private bool called = false;
    void Start()
    {
        InvokeRepeating("Fire", 2f, 0.1f);
    }

    private void Init()
    {
        angle = 0f;
        armCount = 2;
        loopTime = 0;
        CancelInvoke();
        called = true;
    }

    private void Update()
    {
        if (called)
        {
            InvokeRepeating("Fire", 2f, 0.1f);
            called = false;
        }
    }
    void Fire()
    {
        if (!GetComponent<FirePattern1>().GameStarted)
            return;
        if (armCount > 6)
        {
            var scriptName = GetComponent<GenerateRandomPattern>().chooseAPattern(3);
            GetComponent<GenerateRandomPattern>().EnableComp(scriptName);
            this.enabled = false;
            Init();
            return;
        }
        if (loopTime > 120)
        {
            loopTime = 0;
            StartCoroutine(waiter());
            armCount++;
        }
        for (int i = 0; i < armCount; i++)
        {

            float bulDirX = transform.position.x + Mathf.Sin(((angle + (360 / armCount) * i) * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos(((angle + (360 / armCount) * i) * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

            bul.GetComponent<Bullet>().moveSpeed = patternSpeed;
            angle += 1f;

            if (angle >= 360f)
            {
                angle = 0f;
            }

        }
        loopTime++;

    }

    IEnumerator waiter()
    {
        yield return new WaitForSecondsRealtime(10);

    }
}
