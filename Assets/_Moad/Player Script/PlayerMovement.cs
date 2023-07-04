using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;
    [SerializeField] float MovementSpeed;
    [SerializeField] float JumpForce;
    [SerializeField] Vector3 range;
    [SerializeField] Transform GroundPos;
    [SerializeField] LayerMask GroundLayer;
    float MoveInput;
    Rigidbody2D Mybody;
    public bool IsFacingRight;
    Animator anim;
    [HideInInspector]
    public int Keycount;

    
    //public Joystick joystick;
    private void Awake()
    {
    
        Mybody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        IsFacingRight = true;
        //Jumpheight = 0.4f;
    }
    private void FixedUpdate()
    {
      
        Movement();
        CheckCollisionForJump();
    }
    void Movement()
    {
        MoveInput = Input.GetAxisRaw("Horizontal") * MovementSpeed/*joystick.Horizontal */;
       
      
        anim.SetFloat("speed", Mathf.Abs(MoveInput));
        Mybody.velocity = new Vector2(MoveInput, Mybody.velocity.y);
        
      
        if (!IsFacingRight && MoveInput > 0 || IsFacingRight && MoveInput < 0)
        {
            Flip();
        }
    }
    void Flip()
    {
        IsFacingRight = !IsFacingRight;
        Vector3 LocalScale = transform.localScale;
        LocalScale.x *= -1;
        transform.localScale = LocalScale;
    }
  public  void CheckCollisionForJump()
    {
        Collider2D BottomHit = Physics2D.OverlapBox(GroundPos.position, range, 0, GroundLayer);
      
        if(BottomHit != null)
        {
          //  Debug.Log(BottomHit);
            if (BottomHit.gameObject.tag=="Ground" && Input.GetKey(KeyCode.Space))
            {
                //   Debug.Log("Yes");
            //    SoundManager.instance.JumpSound();
                anim.SetBool("jump", true);
                Invoke("setjumpfalse", .3f);
                Mybody.velocity = new Vector2(Mybody.velocity.x, JumpForce);
            }
            else
            {
                anim.SetBool("jump", false);
            }
        }
    }

    public void setjumpfalse()
    {
        anim.SetBool("jump", false);

    }
}