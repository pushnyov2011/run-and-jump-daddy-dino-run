﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawntext : MonoBehaviour
{
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(prefab, transform.position, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
