using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enimy : MonoBehaviour
{
    [SerializeField] private float speed = 5;
    [SerializeField] private float start;
    [SerializeField] private float end = -10;
    public bool left = true;
    Vector3 direction;
   // public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("L") == 0)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
            if (transform.position.x <= end && left)
            {
                Destroy(gameObject);


            }
            if (transform.position.x >= end && !left)
            {
                Destroy(gameObject);


            }
        }

    }

    void Move()
    {

        direction.x = -1;


        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        Vector3 movement = transform.position;
    }
    }
