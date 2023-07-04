using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer
{
    public class EnemyAI1 : MonoBehaviour
    {
        public float moveSpeed = 1f;
        public LayerMask ground;
        public LayerMask wall;

        private Rigidbody2D rigidbody;
        public Collider2D triggerCollider;

        public PlayerHealth1 playerHealth;
        public int damage = 1;

        public SpriteRenderer enemySr;
        public EnemyAI1 enemyMovement;

        public AudioSource damageSound;


        // Start is called before the first frame update
        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
        }

        // Update is called once per frame
        void Update()
        {
            rigidbody.velocity = new Vector2(moveSpeed, rigidbody.velocity.y);
            damageSound = GetComponent<AudioSource>();
        }

        //void FixedUpdate()
        //{
        // if (!triggerCollider.IsTouchingLayers(ground) || triggerCollider.IsTouchingLayers(wall))
        // {
        // Flip();
        // }
        //}

        private void Flip()
        {
            transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
            moveSpeed *= -1;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "wall")
            {
                Flip();
            }

            if (collision.gameObject.tag == "Player")
            {
                playerHealth.TakeDamage(damage);
                damageSound.Play();
                Flip();

                if (playerHealth.health <= 0)
                {
                    enemySr.enabled = false;
                   enemyMovement.enabled = false;
               }
            }
        }
    }

}

