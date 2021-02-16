using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectable : MonoBehaviour {

	void OnTriggerEnter()
    {
        Player.CollectSphere();
        Destroy(gameObject);
    }
}
