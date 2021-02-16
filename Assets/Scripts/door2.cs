using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door2 : MonoBehaviour {


    void OnTriggerEnter(Collider other)
    {
        // trigger the event, pass tag as string
        if (other.tag == "Player")
        {
            events2.DoorOpened(gameObject.tag);
        }
            
    }
}
