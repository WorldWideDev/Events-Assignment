using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {

	void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        // trigger the event, pass tag as string
        if(other.tag == "Player")
            events1.DoorOpened(gameObject.tag);
    }
}
