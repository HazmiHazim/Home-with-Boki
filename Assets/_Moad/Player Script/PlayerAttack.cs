using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PlayerAttack : MonoBehaviour
{
    Animator anim;
    bool Timetoreset;
    [SerializeField] float defaultcombotimer;
    float currentcombotimer;
    int combo;
    [SerializeField] Transform attackpos;
    [SerializeField] LayerMask enemylayer;

    //[SerializeField] float Attackrange;
    [SerializeField] int demage;
   // string Swordattackstring;
    public float distance;
    bool attackonce;


    bool key;
    private void Awake()
    {
        attackonce = true;
        anim = GetComponent<Animator>();
    }
    private void Start()
    {
        
    //    Swordattackstring = TagManager.instance.GetPlayerAttackParameter();
        
    }
    private void Update()
    {
      
        SwordAttack();
        
    

    }


   
    public void SwordAttack()
    {
        if (Input.GetKey(KeyCode.J))
        {
         //   SoundManager.instance.Attackclipsound();
            // Debug.Log("calling");

            anim.SetBool("attack", true);



        }
        else
        {

            anim.SetBool("attack", false);
        }
    }


    public void attack()
    {
        SoundManager.Instance.PlayAttackSound();

        currentcombotimer = defaultcombotimer;
        Timetoreset = true;
        float castdir = distance;
        if (transform.localScale.x == -1)
        {
            castdir = -distance;
        }

        Vector2 endpos = attackpos.position + Vector3.right * castdir;
        RaycastHit2D hit = Physics2D.Linecast(attackpos.position, endpos, 1 << LayerMask.NameToLayer("Enemy"));
        if (hit.collider != null)
        {



            Debug.Log(hit.collider.name);
            if (hit.collider.gameObject.tag == "Enemy")
            {
                Destroy(hit.collider.gameObject);

                // EnemyHealth.instance.TakeDemage(demage);
                //hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDemage(10);

            }

            if (hit.collider.gameObject.tag == "obj")
            {
                //  Destroy(hit.collider.gameObject);

                // EnemyHealth.instance.TakeDemage(demage);
                int result = int.Parse(hit.collider.gameObject.GetComponentInChildren<TMP_Text>().text);
                if (result == GameManager.Instance.result)
                {
                    key = true;
                    Destroy(hit.collider.gameObject);
                    GameManager.Instance.SpawnKey(hit.collider.gameObject.transform.position);
                }
                else
                {
                    // key = false;
                    this.GetComponent<PlayerHealth>().TakeDamage(1);
                    Destroy(hit.collider.gameObject);
                    // Debug.Log("game over");
                }

            }
            //Debug.Log("yellow" + "Not null");
            Debug.DrawLine(attackpos.position, endpos, Color.yellow);
        }
        else
        {

            //Debug.Log("red");
            Debug.DrawLine(attackpos.position, endpos, Color.red);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("door"))
        {
            if(key)
            {
                collision.gameObject.GetComponent<Animator>().SetTrigger("door");

            }
        }
    }


    
}
