using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using People;

public class delChaining : MonoBehaviour {

    delegate void CoolDelegate();
    delegate int WowDelegate();


	// Use this for initialization
	void Start () {
        CoolDelegate d = Foo;
        d += Goo;
        d += Tru;
        d();

        WowDelegate w = One;
        w += Two;
        w += Three;

        Debug.Log(w());
        displayAllReturns(w);
	}

    void displayAllReturns(WowDelegate del)
    {
        foreach (WowDelegate n in del.GetInvocationList())
            Debug.Log(n());
    }

    static void Foo() { Debug.Log("Foo()"); }
    static void Goo() { Debug.Log("Goo()"); }
    static void Tru() { Debug.Log("Tru()"); }

    static int One() { return 1; }
    static int Two() { return 2; }
    static int Three() { return 3; }
	
}
