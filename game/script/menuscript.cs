using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
public class menuscript : MonoBehaviour
{
    public GameObject blackfon;
    // Start is called before the first frame update
    void Start()
    {
        blackfon.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetMouseButtonDown(0))
        { SceneManager.LoadScene(1);
            blackfon.SetActive(true);
        }
    }
}
