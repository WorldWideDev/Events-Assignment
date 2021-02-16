using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public static int score;

    public delegate void CollectionHandler();
    public static event CollectionHandler onCollect;

    public delegate void OnChangeColor(Color color);
    public static OnChangeColor onChangeColor;


    public static void CollectSphere()
    {
        if (onCollect != null)
        {
            score += 1;
            onCollect();
        }
    }

	// Use this for initialization
	void Start () {
        Debug.Log("IM ALIVE");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            AttackEnemy(Color.cyan);
        }
		
	}
    void AttackEnemy(Color color)
    {
        if(onChangeColor != null)
        {
            onChangeColor(color);
        }
    }
}
