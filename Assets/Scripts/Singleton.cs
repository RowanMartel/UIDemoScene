using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
}