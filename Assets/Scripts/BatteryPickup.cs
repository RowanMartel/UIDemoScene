using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    private void Update()
    {
        transform.Rotate(0, Time.deltaTime * 30, 0, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;

        other.transform.root.GetComponentInChildren<Battery>().ModifyLife(15);
        Destroy(gameObject);
    }
}