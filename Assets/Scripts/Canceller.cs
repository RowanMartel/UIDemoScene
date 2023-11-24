using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Canceller : MonoBehaviour
{
    Transform playerTransform;
    NavMeshAgent agent;
    PauseMenu pauseMenu;

    void Start()
    {
        pauseMenu = Singleton.instance.GetComponentInChildren<PauseMenu>();
        agent = GetComponent<NavMeshAgent>();
        playerTransform = FindObjectOfType<FirstPersonControllerModified>().transform;
    }

    void Update()
    {
        agent.SetDestination(playerTransform.position);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        pauseMenu.Open();
        pauseMenu.LockReturn();
    }
}