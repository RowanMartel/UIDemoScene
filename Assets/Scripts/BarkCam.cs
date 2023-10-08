using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BarkCam : MonoBehaviour
{
    [SerializeField] Image barkImage;

    private void Start()
    {
        SceneManager.activeSceneChanged += OnSceneChanged;
        Dissapear();
    }

    public void Reappear()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(true);
    }
    public void Dissapear()
    {
        for (int i = 0; i < transform.childCount; i++)
            transform.GetChild(i).gameObject.SetActive(false);
    }

    public void AssignToBark()
    {
        TreeBark[] treeBarks = FindObjectsByType<TreeBark>(FindObjectsSortMode.None);
        foreach (TreeBark treeBark in treeBarks)
        {
            if (treeBark.barkCam == null)
            {
                treeBark.barkCam = this;
                treeBark.barkCamImg = barkImage;
            }
        }
    }

    void OnSceneChanged(Scene current, Scene next)
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
            AssignToBark();
    }
}