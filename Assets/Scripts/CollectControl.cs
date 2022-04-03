using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectControl : MonoBehaviour
{
    public Transform suitcaseFirstTransform;
 

    
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Collect"))
        {

            Debug.Log("Temas Var");
            other.gameObject.transform.position = transform.localPosition + Vector3.up;
            
            Destroy(gameObject.GetComponent<CollectControl>());
            other.gameObject.AddComponent<CollectControl>();
            //other.gameObject.GetComponent<BoxCollider>().isTrigger = false;
            other.gameObject.AddComponent<NodeMovement>();
            other.gameObject.GetComponent<NodeMovement>().connectedNode = transform;
            other.gameObject.tag = "Collected";

        
        }
    }
}
