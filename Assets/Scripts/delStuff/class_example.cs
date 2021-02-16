using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using People;

// our class definition now lives in a namespace
namespace People
{
    class Person
    {
        // our person has a name
        public string Name;
        
        // our constructor method
        public Person(string name)
        {
            this.Name = name;
        }

        
    }
}


public class class_example : MonoBehaviour {
    
	void Start () {

        // now we need to pass a string when instantiating a Person
        Person d = new Person("Marcus");

        // lets see what d is at run time
        Debug.Log(d.Name);

	}
}
