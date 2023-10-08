using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TreeBark : MonoBehaviour
{
    [SerializeField] List<Sprite> barkList;
    public Sprite barkImg;
    public BarkCam barkCam;
    public Image barkCamImg;

    private void Start()
    {
        GetRandomBark();
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            barkCam.Reappear();
            if (barkCamImg.sprite == null)
                barkCamImg.sprite = barkImg;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            barkCamImg.sprite = null;
            barkCam.Dissapear();
        }
    }

    void GetRandomBark()
    {
        var random = new System.Random();
        int index = random.Next(barkList.Count);
        barkImg = (barkList[index]);
    }
}