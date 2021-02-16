using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


namespace Sengoku

{
    public enum Clan
    {
        Oda,
        Toyotomi,
        Tokugawa
    }

    public class Human
    {
        protected string Name;
        protected int Health;

        public Human(string name, int health)
        {
            this.Name = name;
            this.Health = health;

        }

        public void WasAttacked(Human victim, Human perp)
        {
            Debug.Log("OH SHIT " + victim.Name + " WAS ATTACKED BY " + perp.Name);
            victim.Health -= 5;
            Debug.Log(victim.Name + " now has " + victim.Health.ToString() + " health");
            if (victim == this)
            {

            }

        }

        public Dictionary<string, string> DisplayDeets()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("Name", this.Name);
            dict.Add("Health", this.Health.ToString());
            return dict;
        }
    }


    public class Shogun : Human
    {
        //string Name;
        //int Health;
        public Clan Faction;

        public Shogun(string name, int health, Clan c) : base(name, health)
        {
            //this.Name = name;
            //this.Health = health;
            this.Faction = c;
        }

        public delegate void PayUp(float cash);
        public event PayUp onPaymentDelivered;




        public void PayTheSamurai(float cash)
        {
            if (onPaymentDelivered != null)
                onPaymentDelivered(cash);
        }
    }

    public class Samurai : Human
    {
        public float CashFlow;

        public Samurai(Shogun boss, string name, int health, float cash) : base(name, health)
        {
            this.CashFlow = cash;

            // register Gettin paid to event
            boss.onPaymentDelivered += GettinPaid;
            this.onMelee += WasAttacked;
        }

        public delegate void Attack(Human victim, Human perp);
        public event Attack onMelee;

        void GettinPaid(float cash)
        {
            Debug.Log("Hello I am " + this.Name);
            Debug.Log("Noice boss hooking it up with :" + cash);
            this.CashFlow += cash;
            Debug.Log("I have: " + this.CashFlow + " now");
            Debug.Log("-----------------------");
        }

        public void MeleeAttack(Human victim, Human perp)
        {
            if (onMelee != null)
            {
                onMelee(victim, perp);
            }

        }
    }

    public class dangerousDelExample : MonoBehaviour
    {

        public Shogun Tokugawa;
        public Samurai Musashi;
        public Samurai Devon;

        void Awake()
        {
            Tokugawa = new Shogun("Tokugawa", 100, Clan.Tokugawa);
            Musashi = new Samurai(Tokugawa, "Musashi", 100, 0);
            Devon = new Samurai(Tokugawa, "Devon", 100, 5);
        }

        void Start()
        {
            Dictionary<string, string> d = Devon.DisplayDeets();
            foreach (var pair in d)
            {
                Debug.Log(pair.Key);
                Debug.Log(pair.Value);
            }
        }

        void Update()
        {
            if (Input.GetKeyDown("n"))
            {
                Tokugawa.PayTheSamurai(100);
            }
            if (Input.GetKeyDown("a"))
            {
                Devon.MeleeAttack(Musashi, Devon);
            }
            if (Input.GetKeyDown("m"))
            {
                Devon.MeleeAttack(Devon, Tokugawa);
            }
        }

    }
}

