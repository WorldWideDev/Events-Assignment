using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HudDisplay : MonoBehaviour {

    public Text message;

    void Awake()
    {
        events1.onDoorOpened += DisplayMessage;
    }

    void DisplayMessage(string doorColor)
    {
        StartCoroutine("MessageSequence", doorColor);
    }


    IEnumerator MessageSequence(string doorColor)
    {
        message.text = "You opened the " + doorColor + " door";
        message.enabled = true;
        yield return new WaitForSeconds(3);
        message.enabled = false;
    }
   
}
