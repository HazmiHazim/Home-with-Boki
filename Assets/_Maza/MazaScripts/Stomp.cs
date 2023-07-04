using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp : MonoBehaviour
{
    public float force;
    bool stomped = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("Player"))
        {
            Rigidbody2D playerRb = trigger.GetComponent<Rigidbody2D>();
            playerRb.AddForce(Vector2.up * force);
            stomped = true;
            BoxCollider2D boxCollider = transform.parent.gameObject.GetComponent<BoxCollider2D>();
            boxCollider.enabled = false;
        }
    }

    void OnBecameInvisible()
    {
        if (stomped == true)
        {
            Destroy(transform.parent.gameObject);
        }
    }
}
