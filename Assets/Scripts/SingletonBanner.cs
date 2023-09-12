using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBanner : MonoBehaviour
{
    private static SingletonBanner Obje = null;

    public void Awake()
    {
        if (Obje == null)
        {
            Obje = this;
            DontDestroyOnLoad(this);
        }
        else if (this != Obje)
        {
            Destroy(gameObject);
        }
    }
}
