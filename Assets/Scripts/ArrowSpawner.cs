using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ArrowSpawner : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform goalTransform;

    [SerializeField] GameObject arrowPrefab;
    List<GameObject> pool = new List<GameObject>();
    [SerializeField] int poolSize;
    [SerializeField] float spawnTime;
    float spawnTimer;

    void Start()
    {
        spawnTimer = 0;
        for (int i = 0; i < poolSize; i++)
        {
            pool.Add(Instantiate(arrowPrefab));
            pool[i].SetActive(false);
        }
    }

    void Update()
    {
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnTime)
        {
            SpawnArrow();
            spawnTimer = 0;
        }
    }

    void SpawnArrow()
    {
        foreach (GameObject arrow in pool)
        {
            if (!arrow.activeSelf)
            {
                arrow.transform.position = playerTransform.position;
                arrow.SetActive(true);
                arrow.GetComponent<NavMeshAgent>().SetDestination(goalTransform.position);
                break;
            }
        }
    }
}