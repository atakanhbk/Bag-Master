using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class collectBags : MonoBehaviour
{
    public GameObject Truck;
    public ParticleSystem celebrate;
    float bagCounter = 0;

   
     IEnumerator OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Collected")
        {
            other.gameObject.SetActive(false);
            Truck.transform.DOScale(4,0.125f);
            yield return new WaitForSeconds(0.1f);
            Truck.transform.DOScale(3.2f, 0.125f);
            bagCounter++;
        }      
    }

   void Update()
    {
        if (bagCounter>=4)
        {
            celebrate.Play();       
        }
    }
}
