using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnPlane : MonoBehaviour
{
    [SerializeField] Vector3 respawnPos;
    [SerializeField] Vector3 respawnDir;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CharacterController>().enabled = false;
            other.transform.parent.GetChild(1).position = respawnPos;
            other.GetComponent<CharacterController>().enabled = true;
            other.transform.parent.GetChild(1).eulerAngles = respawnDir;
        }
    }
}