using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playpausechange : MonoBehaviour
{
    private static playpausechange ppc;

    void Awake()
    {
        if (ppc == null)
        {
            ppc = this;
            DontDestroyOnLoad(ppc);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
