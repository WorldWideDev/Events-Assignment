using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HudDisplay2 : MonoBehaviour {

    public Text message;

    void Start()
    {
        events2.OnDoorOpened += DisplayMessage;
    }

    void DisplayMessage(object sender, events2.DoorOpenedEvent e)
    {
        Debug.Log(sender);
        StartCoroutine("MessageSequence", e.DoorColor);
    }


    IEnumerator MessageSequence(string doorColor)
    {
        message.text = "You opened the " + doorColor + " door";
        switch (doorColor)
        {
            case "Red":
                message.color = Color.red;
                break;
            case "Green":
                message.color = Color.green;
                break;
            case "Yellow":
                message.color = Color.yellow;
                break;

        }
        message.enabled = true;
        yield return new WaitForSeconds(3);
        message.enabled = false;
    }
   
}
