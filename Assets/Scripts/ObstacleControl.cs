using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class ObstacleControl : MonoBehaviour
{
     void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag =="Collected")
        {

          
            other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            other.gameObject.transform.parent = null;
            other.gameObject.GetComponent<Rigidbody>().useGravity = true;
            other.gameObject.tag = "onTouchObstacle";
            
        }
    }
}
