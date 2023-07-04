using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyObject : MonoBehaviour
{
    public static DontDestroyObject Instance;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.DontDestroyOnLoad(this.gameObject);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static implicit operator DontDestroyObject(AnswerMainCam v)
    {
        throw new NotImplementedException();
    }
}
