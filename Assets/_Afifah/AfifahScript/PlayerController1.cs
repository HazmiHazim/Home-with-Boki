using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Platformer
{

    public class PlayerController1 : MonoBehaviour
    {
        public float movingSpeed;
        public float jumpForce;
        public float moveInput;

        private bool facingRight = false;
        [HideInInspector]
        public bool deathState = false;

        public bool isGrounded;
        public Transform groundCheck;

        private Rigidbody2D rigidbody;

   
        public GameObject triggerDoor;
        public GameObject triggerFlag;
        public GameObject closedDoor;

        public EnemyAI1 enemy;

        public Animator animator;
        private GameManager1 gameManager;

        public AudioSource collectSound;
        public AudioSource damageSound;
        public AudioSource rightAnswer;

        public PlayerHealth1 playerHealth;
        public int damage = 1;

        public GameObject[] Question;
        public GameObject[] Answer;
        public GameObject key;

        PlayerController p1;

        // Start is called before the first frame update
        void Start()
        {
            rigidbody = GetComponent<Rigidbody2D>();
            animator = GetComponent<Animator>();
            gameManager = GameObject.Find("GameManager").GetComponent<GameManager1>();
          
           
            rigidbody.freezeRotation = true;
            collectSound = GetComponent<AudioSource>();
            triggerFlag = GameObject.Find("Flag"); //to set trigger flag 
            triggerFlag.GetComponent<BoxCollider2D>().isTrigger = false;
            closedDoor = GameObject.Find("ClosedDoor");
            triggerDoor = GameObject.Find("OpenedDoor"); //to set trigger finish 
            triggerDoor.GetComponent<BoxCollider2D>().isTrigger = false;
        
        }

        public void FixedUpdate()
        {
            CheckGround();
        }

        // Update is called once per frame
        void Update()
        {


            if (Input.GetButton("Horizontal"))
            {
                moveInput = Input.GetAxis("Horizontal");
                Vector3 direction = transform.right * moveInput;
                transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, movingSpeed * Time.deltaTime);
                animator.SetFloat("Speed", Mathf.Abs(moveInput));
             //   animator.SetInteger("playerState", 1); // Turn on run animation
            }
            else
            {
               // if (isGrounded) animator.SetInteger("playerState", 0); // Turn on idle animation
            }

            if (Input.GetKeyDown(KeyCode.Space)  && isGrounded)
            {
                rigidbody.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
            }

            //  if (!isGrounded) animator.SetInteger("playerstate", 2); // Turn on jump animation

           // if (Input.GetKeyDown(KeyCode.Space) && isGrounded) // Hit answer
           // {

          //  }


            if (facingRight == false && moveInput < 0)
            {
                Flip();
            }

            else if (facingRight == true && moveInput > 0)
            {
                Flip();
            }


        }

        public void Flip()
        {
            facingRight = !facingRight;
            Vector3 Scaler = transform.localScale;
            Scaler.x *= -1;
            transform.localScale = Scaler;
        }



        public void CheckGround()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheck.transform.position, 0.2f);
            isGrounded = colliders.Length > 1;
        }

        public void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "Enemy")
            {
                //deathState = true; //Say to GameManager that player is dead
            }
            else
            {
                //deathState = false;
            }

            if (other.gameObject.tag == "Box")
            {
              //  damageSound.Play();
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            //anim.SetBool("isJump", false);

            if (other.gameObject.tag == "Fruit")
            {
                gameManager.scoreCounter += 5;
                collectSound.Play();
                Destroy(other.gameObject);
            }

            if (other.gameObject.tag == "Diamond")
            {
                gameManager.scoreCounter += 10;
                collectSound.Play();
                Destroy(other.gameObject);
            }

            if (other.gameObject.tag == "Key")
            {
                gameManager.scoreCounter += 10;
                Destroy(other.gameObject);
                collectSound.Play();
                triggerFlag.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;

            }

            if (other.gameObject.tag == "flag")
            {
                closedDoor.SetActive(false);
                triggerDoor.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                // openDoor.SetActive(true);
            }

            if (other.gameObject.tag == "Spike")
            {
                playerHealth.TakeDamage(damage);
                damageSound.Play();
            }

            


            for (int i = 0; i < Answer.Length; i++)
            {
                if (other.gameObject == Answer[0])
                {
                    gameManager.scoreCounter += 4;
                    Destroy(other.gameObject);
                    rightAnswer.Play();
                    Answer[1].gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                    for (int j = 0; j < Question.Length; j++)
                    {
                        Question[0].SetActive(false);
                        Question[1].SetActive(true);
                    }
                }else if (other.gameObject == Answer[1])
                {
                    gameManager.scoreCounter += 4;
                    Destroy(other.gameObject);
                    rightAnswer.Play();
                    Answer[2].gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                    for (int j = 0; j < Question.Length; j++)
                    {
                        Question[1].SetActive(false);
                        Question[2].SetActive(true);
                    }
                }
                else if (other.gameObject == Answer[2])
                {
                    gameManager.scoreCounter += 4;
                    Destroy(other.gameObject);
                    rightAnswer.Play();
                    Answer[3].gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                    for (int j = 0; j < Question.Length; j++)
                    {
                        Question[2].SetActive(false);
                        Question[3].SetActive(true);
                    }
                }
                else if (other.gameObject == Answer[3])
                {
                    gameManager.scoreCounter += 4;
                    Destroy(other.gameObject);
                    rightAnswer.Play();
                    //key.gameObject.SetActive(true);
                    Answer[4].gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                    for (int j = 0; j < Question.Length; j++)
                    {
                        Question[3].SetActive(false);
                        Question[4].SetActive(true);
                    }
                }
                else if (other.gameObject == Answer[4])
                {
                    gameManager.scoreCounter += 4;
                    Destroy(other.gameObject);
                    rightAnswer.Play();
                    //key.gameObject.SetActive(true);
                    Answer[5].gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                    for (int j = 0; j < Question.Length; j++)
                    {
                        Question[4].SetActive(false);
                        Question[5].SetActive(true);
                    }
                }
                else if (other.gameObject == Answer[5])
                {
                    gameManager.scoreCounter += 4;
                    Destroy(other.gameObject);
                    rightAnswer.Play();
                    //key.gameObject.SetActive(true);
                    Answer[6].gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                    for (int j = 0; j < Question.Length; j++)
                    {
                        Question[5].SetActive(false);
                        Question[6].SetActive(true);
                    }
                }
                else if (other.gameObject == Answer[6])
                {
                    gameManager.scoreCounter += 4;
                    Destroy(other.gameObject);
                    rightAnswer.Play();
                    //key.gameObject.SetActive(true);
                    Answer[7].gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                    for (int j = 0; j < Question.Length; j++)
                    {
                        Question[6].SetActive(false);
                        Question[7].SetActive(true);
                    }
                }
                else if (other.gameObject == Answer[7])
                {
                    gameManager.scoreCounter += 4;
                    Destroy(other.gameObject);
                    rightAnswer.Play();
                    //key.gameObject.SetActive(true);
                    Answer[8].gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                    for (int j = 0; j < Question.Length; j++)
                    {
                        Question[7].SetActive(false);
                        Question[8].SetActive(true);
                    }
                }
                else if (other.gameObject == Answer[8])
                {
                    gameManager.scoreCounter += 4;
                    Destroy(other.gameObject);
                    rightAnswer.Play();
                    //key.gameObject.SetActive(true);
                    Answer[9].gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                    for (int j = 0; j < Question.Length; j++)
                    {
                        Question[8].SetActive(false);
                        Question[9].SetActive(true);
                    }
                }
                else if (other.gameObject == Answer[9])
                {
                    gameManager.scoreCounter += 4;
                    Destroy(other.gameObject);
                    rightAnswer.Play();
                    key.gameObject.SetActive(true);
                    //Answer[].gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
                    for (int j = 0; j < Question.Length; j++)
                    {
                        Question[9].SetActive(false);
                        Question[10].SetActive(true);
                    }
                }
            }


        if (other.gameObject.tag == "finish")
            {

                gameManager.isFinish = true;
            }

         
        }




    }

}
