using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomp1 : MonoBehaviour
{
    public float force;
    bool stomped = false;
    public GameObject player;

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
        if (player.gameObject.tag == "Player")
        {

            //Rigidbody2D playerRb = trigger.GetComponent<Rigidbody2D>();
            player.GetComponent<Rigidbody2D>().AddForce(Vector2.up * force);
            stomped = true;
            BoxCollider2D boxCollider = transform.parent.gameObject.GetComponent<BoxCollider2D>();
            boxCollider.enabled = false;
        }
    }

    void OnBecomeVisible()
    {
        if (stomped == true)
        {
            this.GetComponent<BoxCollider2D>().isTrigger = false;
            Destroy(transform.parent.gameObject);
            
        }
    }
}
