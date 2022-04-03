using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Translate(new Vector3(0, 0, speed*Time.deltaTime));
    }

 
}
