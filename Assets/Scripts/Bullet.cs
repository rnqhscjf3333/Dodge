using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody bulletRigidbody;

    // Start is called before the first frame update
    void Start()
    {
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
