using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class moreEventsandDels : MonoBehaviour
{
    class CowTippedEventArgs : EventArgs
    {
        public CowState currCowState { get; private set; }
        public CowTippedEventArgs(CowState currState)
        {
            currCowState = currState;
        }
    }

    public enum CowState
    {
        Awake,
        Sleeping,
        Dead
    }

    class Cow
    {
        public string Name { get; set; }
        public event EventHandler<CowTippedEventArgs> Moo;
        public void BeTippedOver()
        {
            if (Moo != null)
                Moo(this, new CowTippedEventArgs(CowState.Awake));
        }
    }

    static void Giggle(object sender, CowTippedEventArgs e)
    {
        Cow c = sender as Cow;
        Debug.Log("GIGGLE GIGGLE... We made " + c.Name + " Moo");
        switch (e.currCowState)
        {
            case CowState.Awake:
                Debug.Log("RUN!");
                break;
            case CowState.Sleeping:
                Debug.Log("TICKLEING");
                break;
            case CowState.Dead:
                Debug.Log("YUM TIME FOR DINZ");
                break;
        }
    }

    void Start()
    {
        Cow c1 = new Cow { Name = "Devon" };
        Cow c2 = new Cow { Name = "McGiggles" };
        c1.Moo += Giggle;
        c2.Moo += Giggle;
        Cow victim = new System.Random().Next() % 2 == 0 ? c1 : c2;
        victim.BeTippedOver();
    }

}
