using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeBark : MonoBehaviour
{
    [SerializeField] List<Sprite> barkList;
    public Sprite barkImg;
    GameObject barkCam;
    Image barkCamImg;

    private void Start()
    {
        barkCam = GameObject.FindWithTag("Bark");
        barkCamImg = barkCam.GetComponentInChildren<Image>();
        var random = new System.Random();
        int index = random.Next(barkList.Count);
        barkImg = (barkList[index]);
        barkCam.SetActive(false);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            barkCam.SetActive(true);
            barkCamImg.sprite = barkImg;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            barkCam.SetActive(false);
        }
    }
}