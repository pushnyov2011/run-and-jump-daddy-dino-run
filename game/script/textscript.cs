using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class textscript : MonoBehaviour
{
    public Text tx;
    public float time;
    public GameObject gm;
    public bool go;
    // Start is called before the first frame update
    void Start()
    {
        go = true;
       // gm = GetComponent<GameObject>();
        tx.text = "READY?";


    }

    // Update is called once per frame
    void Update()
    {
        if (go)
        {
            time += Time.deltaTime;
            if (time > 0.3f)
            {
                tx.text = "GO";
                // estroy(gameObject, 0.3f);

            }
            if (time > 0.8f)
            {
                gm.SetActive(false);
                go = false;
            }
        }
    }
}
