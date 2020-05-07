using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawanothejbject : MonoBehaviour
{
    public GameObject[] prefab;
    public float timeF;
    public float time_s = 2.5f;
    public int i;

    // Start is called before the first frame update
    void Start()
    {

    }
    void Update()
    {
        if (PlayerPrefs.GetInt("L") == 0)
        {
            timeF += Time.deltaTime;
            if (timeF >= time_s)
            {
                i = Random.Range(0, prefab.Length);
                spawn();
                timeF = 0;
            }
        }
    }
    public void spawn()
    {

        // Create knife if Trunk is alive!

        float randY = Random.Range(-1.375f, 3.67f);
        Vector3 wheretospawn = new Vector3(transform.position.x, randY);
        Instantiate(prefab[i], wheretospawn, Quaternion.identity);
       // Instantiate(prefab[i], transform.position, Quaternion.identity);
    }
}
