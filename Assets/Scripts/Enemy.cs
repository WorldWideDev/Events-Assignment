using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    MeshRenderer renderer;

	void Awake()
    {
        Player.onChangeColor += EnemyHit;
    }

    void EnemyHit(Color color)
    {
        Debug.Log("I WAS HIT");
        renderer = GetComponent<MeshRenderer>();
        renderer.material.color = color;
        Player.onChangeColor = null;
    }
}
