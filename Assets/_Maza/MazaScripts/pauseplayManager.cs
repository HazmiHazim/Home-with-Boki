using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pauseplayManager : MonoBehaviour
{
    public Image playIcon;
    public Sprite pauseIcon;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void IconChange()
    {
        playIcon.sprite = pauseIcon;
    }
}
