using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sfxManager : MonoBehaviour
{
    public static AudioClip clickSound, correctSound, wrongSound, gameoverSound, fruitSound, enemyCollideSound, jumpSound;
    static AudioSource audiosrc;

    // Start is called before the first frame update
    void Start()
    {
        clickSound = Resources.Load<AudioClip>("click");
        correctSound = Resources.Load<AudioClip>("correct");
        wrongSound = Resources.Load<AudioClip>("wrong");
        gameoverSound = Resources.Load<AudioClip>("game over");
        fruitSound = Resources.Load<AudioClip>("fruit");
        enemyCollideSound = Resources.Load<AudioClip>("enemy colide");
        jumpSound = Resources.Load<AudioClip>("jump");

        audiosrc = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public static void PlaySound(string clip)
    {
        switch (clip)
        {
            case "click":
                audiosrc.PlayOneShot(clickSound);
                break;
            case "correct":
                audiosrc.PlayOneShot(correctSound);
                break;
            case "wrong":
                audiosrc.PlayOneShot(wrongSound);
                break;
            case "game over":
                audiosrc.PlayOneShot(gameoverSound);
                break;
            case "fruit":
                audiosrc.PlayOneShot(fruitSound);
                break;
            case "jump":
                audiosrc.PlayOneShot(jumpSound);
                break;
            case "enemy collide":
                audiosrc.PlayOneShot(enemyCollideSound);
                break;
        }
    }
}
