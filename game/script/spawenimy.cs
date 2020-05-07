using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;
//using 

public class spawenimy : MonoBehaviour
{
    public GameObject[] prefab;
    public float timeF;
    public float time_s = 2.5f;
    public int i;
    public bool doing = true;
    // Start is called before the first frame update
    void Start()
    {

    }
    public void spawn()
    {

        // Create knife if Trunk is alive!


        Instantiate(prefab[i], transform.position, Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("L") == 0)
        {
            timeF += Time.deltaTime;
            if (timeF >= time_s)
            {if (doing)
                {
                    time_s = Random.Range(1.05f, 1.65f);
                }
                i = Random.Range(0, prefab.Length);
                spawn();
                timeF = 0;
               

            }
        }
    } }
