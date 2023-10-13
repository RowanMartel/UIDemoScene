using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLockHack : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }
}