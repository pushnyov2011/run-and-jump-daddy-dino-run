using UnityEngine;
using System.Collections;

public class movefonscript : MonoBehaviour
{
    public float backgroundSize;
    private Transform cameraTranform;
    private Transform[] layers;
    private float viaZone = 10f;
    private int leftIndex;
    private int rightIndex;


    public Vector3 direction;
    public float speed = 5;

    public bool isLinkedToCamera = false;
    // Use this for initialization
    void Start()
    {
        

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();




    }
    void Move()
    {

        direction.x = -1;


        transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, speed * Time.deltaTime);
        Vector3 movement = transform.position;
        if (isLinkedToCamera)
        {
            Camera.main.transform.Translate(movement);
        }
    }
}
