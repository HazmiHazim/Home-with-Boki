using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    // Start is called before the first frame update

    public AudioSource ad;
    public AudioClip attack;
    public AudioClip death;

    public static SoundManager Instance;
    void Start()
    {
        if(Instance==null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(this.gameObject);
        }    
       
    }

    public void PlayAttackSound()
    {
        ad.clip = attack;
        ad.Play();
    }

    public void PlaydeathSound()
    {
        ad.clip = death;
        ad.Play();
    }
}
