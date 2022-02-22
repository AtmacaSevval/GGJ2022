using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePattern4 : MonoBehaviour
{
    private float angle = 0f;

    private int callingTime = 0;
    [SerializeField] float patternSpeed = 8f;
    bool called = false;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 2f, 3f);
    }


    private void Init()
    {
        angle = 0f;
        callingTime = 0;
        CancelInvoke();
        called = true;
    }

    private void Update()
    {
        if (called)
        {
            InvokeRepeating("Fire", 2f, 3f);
            called = false;
        }
    }
    // Update is called once per frame
    void Fire()
    {
        if (!GetComponent<FirePattern1>().GameStarted)
        {

            return;
        }
        if (callingTime > 10)
        {
            this.enabled = false;
            var scriptName = GetComponent<GenerateRandomPattern>().chooseAPattern(4);
            GetComponent<GenerateRandomPattern>().EnableComp(scriptName);
            Init();
            return;
        }
        int maxNum, minNum;
        var num = Random.Range(0, 360);
        var space = Random.Range(40, 100);
        if (num > space)
        {
            maxNum = num;
            minNum = num - space;
        }
        else
        {
            minNum = num;
            maxNum = num + space;
        }

        for (; 360 >= angle;)
        {
            if (angle >= minNum && angle <= maxNum)
            {


                angle += 10f;
                continue;
            }

            float bulDirX = 5f * Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = 5f * Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.bulletPoolInstance.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<Bullet>().SetMoveDirection(bulDir);

            bul.GetComponent<Bullet>().moveSpeed = patternSpeed;

            angle += 10f;
        }
        angle = 0f;
        callingTime++;
    }
}
