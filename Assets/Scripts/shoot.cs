using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shoot : MonoBehaviour {

    public GameObject bullet;

	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(1))
        {
            ShootBullet();
        }
	}

    void ShootBullet()
    {
        Instantiate(bullet, transform.position, transform.localRotation * Quaternion.Euler(0,180,0));
    }
}
