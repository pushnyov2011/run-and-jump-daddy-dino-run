using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objectfrendly : MonoBehaviour
{
    Vector3 direction;
    public float speed = 3f;
    public float destoyspeed = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("L") == 0)
        {
            Move();
        }
      //  Destroy(gameObject, destoyspeed);
    }
    void Move()
    {

        direction.x = -1;


        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        Vector3 movement = transform.position;
        if (movement.x <= -9.94) { Destroy(gameObject); }
    }

    
}
