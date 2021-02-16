using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class events1 {

    public delegate void DoorHandler(string color);
    public static event DoorHandler onDoorOpened;

    public static void DoorOpened(string color)
    {
        if (onDoorOpened != null)
            onDoorOpened(color);
    }
}
