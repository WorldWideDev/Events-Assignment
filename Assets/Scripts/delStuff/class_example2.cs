using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using People;

namespace People
{
    class Hero
    {
        // protected so we only set these on child classes if using the derived class type
        // this means you can't set Hero.Name from Child, you will have to set Child.Name
        protected string Name;
        protected float Health;

        public Hero(string name, float health)
        {
            this.Name = name;
            this.Health = health;
        }
        public void TakeDamage(float dmg)
        {
            this.Health -= dmg;
            Debug.Log(this.Name + " now has " + this.Health + " health");
        }
    }
    class Ninja : Hero
    {
        public float Stealth;
        public float Strength;
        // Ninja constructor takes the two required attributes it inherits from Human, plus stealth
        public Ninja(string name, int health, float stealth, float strength) : base(name, health)
        {
            this.Stealth = stealth;
        }
        public void SayName()
        {
            Debug.Log(this.Name + " is my name");
        }
        public void Attack(Hero h)
        {
            float dmg = this.Strength * this.Stealth;
            h.TakeDamage(dmg);
        }
    } 
}

public class class_example2 : MonoBehaviour {

    Ninja devon;
    Ninja becca;
    
    void Awake () {
        devon = new Ninja("Devon", 100, 10f, 5f);
        becca = new Ninja("Becca", 100, 5f, 5f);
	}
    void Start()
    {
        devon.SayName();
        Debug.Log(devon.Stealth);
        devon.Attack(becca);
    }
}
