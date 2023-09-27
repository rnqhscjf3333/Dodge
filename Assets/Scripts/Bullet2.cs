using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet2 : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;
    public Transform playertrans = null;
    public float MaxSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
            playertrans = GameObject.FindGameObjectWithTag("Player").transform;
        bulletRigidbody = GetComponent<Rigidbody>();
        //bulletRigidbody.velocity = transform.forward * speed;

        if (transform.position.x > 10)
            transform.position = new Vector3(10, 0.5f, transform.position.z);
        if (transform.position.x < -10)
            transform.position = new Vector3(-10, 0.5f, transform.position.z);
        if (transform.position.z > 10)
            transform.position = new Vector3(transform.position.x, 0.5f, 10);
        if (transform.position.z < -10)
            transform.position = new Vector3(transform.position.x, 0.5f, -10);
    }

    // Update is called once per frame
    void Update()
    {
        if (playertrans)
        {
            bulletRigidbody.transform.LookAt(playertrans);
            bulletRigidbody.AddForce(transform.forward * speed);
        }

        if (bulletRigidbody.velocity.x > MaxSpeed)
        {
            bulletRigidbody.velocity = new Vector3(MaxSpeed, bulletRigidbody.velocity.y, bulletRigidbody.velocity.z);
        }
        if (bulletRigidbody.velocity.x < (MaxSpeed * -1))
        {
            bulletRigidbody.velocity = new Vector3((MaxSpeed * -1), bulletRigidbody.velocity.y, bulletRigidbody.velocity.z);
        }

        if (bulletRigidbody.velocity.z > MaxSpeed)
        {
            bulletRigidbody.velocity = new Vector3(bulletRigidbody.velocity.x, bulletRigidbody.velocity.y, MaxSpeed);
        }
        if (bulletRigidbody.velocity.z < (MaxSpeed * -1))
        {
            bulletRigidbody.velocity = new Vector3(bulletRigidbody.velocity.x, bulletRigidbody.velocity.y, (MaxSpeed * -1));
        }


        if (Mathf.Abs(transform.position.x) > 10 || Mathf.Abs(transform.position.z) > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerController>().Die();
        }
    }
}
