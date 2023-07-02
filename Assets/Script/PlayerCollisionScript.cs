using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionScript : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Obstacle")
        {
            Debug.Log("Hit");
            LifeManagerScript.life = LifeManagerScript.life - 1;
            if (LifeManagerScript.life > 0)
            {
                AudioManager.instance.Play("Hurt Sound");
            }

            if (LifeManagerScript.life <= 0)
            {
                GameManagerScript.isGameOver = true;
                AudioManager.instance.Play("Game Over Sound");
                gameObject.SetActive(false);
            }
            else
            {
                StartCoroutine(bumpToObstacle());
            }
        }
    }

    IEnumerator bumpToObstacle()
    {
        Physics2D.IgnoreLayerCollision(6, 8);
        GetComponent<Animator>().SetLayerWeight(1, 1);
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetLayerWeight(1, 0);
        Physics2D.IgnoreLayerCollision(6, 8, false);
    }
}
