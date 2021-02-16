using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

class TrainSignal
{
    public Action TrainsAComing; // if i add event keyword here, i will prevent direct calls to the delegate
    public void HereComesATrain()
    {
        // there is a ton of logic here
        if(TrainsAComing != null)
            // saves us from the null reference exception cause by line 56
            TrainsAComing();
    }
}

class Car
{
    public string Name;

    public Car(TrainSignal trainSig, string name)
    {
        Name = name;

        // !!observer pattern!!
        trainSig.TrainsAComing += StopTheCar;
    }
    void StopTheCar()
    {
        Debug.Log("SCREEETCH, says the" + " " + this.Name);
    }
}

public class eventsDels : MonoBehaviour {

	// delegates allow references to methods with a matching signature, and can invoke that method through the delegate instanace.

    // events are delegate references with two restrictions:
        // you CANT invoke the delegate reference directly
        // you CANT assign to the delegate reference directly
        // under the hood, it privatizes the field

    void Start()
    {
        TrainSignal trainSignal = new TrainSignal();
        new Car(trainSignal, "Ferrari");
        new Car(trainSignal, "Volvo");
        new Car(trainSignal, "Bus");

        trainSignal.HereComesATrain();

        // being NAUGHTY, invoking the delegate directly
        trainSignal.TrainsAComing();

        //being VERY NAUGHTY, nulling out the delegate
        trainSignal.TrainsAComing = null;

        // now we loose reference to the delegate
        trainSignal.HereComesATrain();
    }

}
