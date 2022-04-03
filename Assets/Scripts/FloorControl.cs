using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorControl : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "onTouchObstacle")
        {
            other.gameObject.SetActive(false);
            GameObject.FindGameObjectWithTag("Player").GetComponent<CollectControl1>().CheckBagsEnable();
        }
    }
    }
