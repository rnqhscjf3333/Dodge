using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;
    public float speed = 8f;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        playerRigidbody.velocity = new Vector3(xInput, 0f, yInput)*speed;
    }
    public void Die()
    {
        GameManager.instance.EndGame();
        gameObject.SetActive(false);
    }
}
