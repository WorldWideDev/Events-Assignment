using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {

    public float BulletLife = 2.0f;
    public float BulletSpeed = 10f;

    IEnumerator Start()
    {
        Debug.Log("Bullet is ALIVE");
        yield return new WaitForSeconds(BulletLife);

        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag != "Player")
        {
            Debug.Log("bullet hit a thing");
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.Translate(-Vector3.forward * BulletSpeed * Time.deltaTime, Space.Self);
    }
}
