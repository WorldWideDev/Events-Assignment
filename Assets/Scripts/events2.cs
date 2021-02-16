using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class events2 : MonoBehaviour {

    //public static events2 Instance { get; private set; }

    //void Awake()
    //{
    //    Instance = this;
    //}

    // defining my event args
    public class DoorOpenedEvent: EventArgs
    {
        public string DoorColor;
        // heres were the actual event args are specified, to access this i would look for something like e.DoorColor
        public DoorOpenedEvent(string doorColor) { DoorColor = doorColor; }
    }

    // my delegate takes in an object and eventargs
    public delegate void DoorOpenedHandler(object sender, DoorOpenedEvent e);

    // my event conforms to the delegate
    public static event DoorOpenedHandler OnDoorOpened;


    public static void DoorOpened(string doorColor)
    {
        Debug.Log("door was opened " + doorColor);
        if (OnDoorOpened != null)
            OnDoorOpened(null, new DoorOpenedEvent(doorColor));
        else
            Debug.Log("door event null");
    }

}
