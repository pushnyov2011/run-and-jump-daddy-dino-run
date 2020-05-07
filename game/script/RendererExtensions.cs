using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class RendererExtensions : MonoBehaviour
{
    public float backgroundSize;
    private Transform cameraTranform;
    private Transform[] layers;
    public float viaZone = 10f;
    private int leftIndex;
    private int rightIndex;
    public float parlaxSpeedd;
    public float lastCameraX;
    private void Start() {

        cameraTranform = Camera.main.transform;
        lastCameraX = cameraTranform.position.x;
        layers = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
            layers[i] = transform.GetChild(i);
        leftIndex = 0;
        rightIndex = layers.Length - 1;
        
    }
     private void Update() {
         float deltaX = cameraTranform.position.x - lastCameraX;
         transform.position += Vector3.right * (deltaX * parlaxSpeedd);
         lastCameraX = cameraTranform.position.x;
         
         if (cameraTranform.position.x < (layers[leftIndex].transform.position.x + viaZone))
             ScrolLeft();
         if (cameraTranform.position.x > (layers[rightIndex].transform.position.x - viaZone))
             ScrolRight();
     }
    private void ScrolLeft() 
    {
        int lastRight = rightIndex;
        layers[rightIndex].position = Vector3.right * (layers[leftIndex].position.x - backgroundSize);
        leftIndex = rightIndex;
        rightIndex--;
        if (rightIndex < 0)
            rightIndex = layers.Length - 1;
    }
    private void ScrolRight() {
        int lastLeft = leftIndex;
        layers[leftIndex].position = Vector3.right * (layers[rightIndex].position.x + backgroundSize);
        rightIndex = leftIndex;
       leftIndex++; 
       if (leftIndex == layers.Length)
           leftIndex = 0;
    }



}
