using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePattern2 : MonoBehaviour
{
    [SerializeField]
    private int bulletsAmount = 10;

    [SerializeField]
    private float startAngle = 0f, endAngle = 360f;
    private int loopTime = 0;


    [SerializeField] float patternSpeed = 8f;
    private bool called = false;
    void Start()
    {
        InvokeRepeating("Fire", 1f, 0.1f);
    }

    private void Init()
    {
        loopTime = 0;
        CancelInvoke();
        called = true;
    }

    private void Update()
    {
        if (called)
        {
            InvokeRepeating("Fire", 1f, 0.1f);
            called = false;
        }
    }
    // Update is called once per frame
    void Fire()
    {
        if (!GetComponent<FirePattern1>().GameStarted)
            return;
        if(loopTime > 30)
        {
            var scriptName = GetComponent<GenerateRandomPattern>().chooseAPattern(2);
            GetComponent<GenerateRandomPattern>().EnableComp(scriptName);
            this.enabled = false;
            Init();
            return;
        }
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = startAngle;

        for(int i = 0; i < bulletsAmount + 1; i++)
        {

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
            angle += angleStep;

        }
        loopTime++;

    }
}
