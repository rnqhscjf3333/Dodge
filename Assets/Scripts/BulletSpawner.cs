using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bullet2Prefab;
    float spawnRateMin = 5f;
    float spawnRateMax = 30f;

    private Transform target;
    private float spawnRate;
    private float timeAfterSpawn;

    // Start is called before the first frame update
    void Start()
    {
        timeAfterSpawn = spawnRateMax;
        spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        timeAfterSpawn += Time.deltaTime*10;

        if (spawnRateMax > spawnRateMin)
        {
            spawnRateMax -= Time.deltaTime*0.1f;
        }

        if (timeAfterSpawn >= spawnRate)
        {
            timeAfterSpawn = 0f;

            GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.transform.LookAt(target);
            bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * Random.Range(4,8);

            if (Random.Range(0, 15) == 0)
            {
                GameObject bullet2 = Instantiate(bullet2Prefab, transform.position, transform.rotation);
                bullet2.GetComponent<Bullet2>().speed = Random.Range(1, 5);
            }
            GameManager.instance.bulletcount += 1;
            spawnRate = Random.Range(spawnRateMin, spawnRateMax);
        }
    }
}
