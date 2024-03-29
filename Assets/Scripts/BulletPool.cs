using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool bulletPoolInstance;

    [SerializeField]
    private GameObject pooledBullet;
    private bool notEnoughBulletsInPool = true;

    private List<GameObject> bullets;
    public GameObject parentObj;

    private void Awake()
    {
        bulletPoolInstance = this;
    }

    private void Start()
    {
        bullets = new List<GameObject>();
    }
    // Update is called once per frame

    public GameObject GetBullet()
    {
        if(bullets.Count > 0)
        {
            for(int i = 0; i< bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }

        if (notEnoughBulletsInPool)
        {
            GameObject bul = Instantiate(pooledBullet);
            bul.SetActive(false);
            bullets.Add(bul);
            bul.transform.parent = parentObj.transform;

            return bul;
        }
        return null;
    }
    void Update()
    {
        
    }
}
