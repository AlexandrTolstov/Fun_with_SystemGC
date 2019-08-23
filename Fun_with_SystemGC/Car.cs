﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fun_with_SystemGC
{
    class Car
    {
        public delegate void CarEngineHandler(string msg);
        public event CarEngineHandler Exploded;
        public event CarEngineHandler AboutToBlow;
        public int CurrentSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public string PetName { get; set; }
        private bool carIsDead;
        public Car() { }
        public Car(string name, int maxSp, int currSp)
        {
            CurrentSpeed = currSp;
            MaxSpeed = maxSp;
            PetName = name;
        }
        //public delegate void CarEngineHandler(string msgForCaller);
        private CarEngineHandler listOfHandlers;
        public void RegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers += methodToCall;
        }
        public void UnRegisterWithCarEngine(CarEngineHandler methodToCall)
        {
            listOfHandlers -= methodToCall;
        }
        public void Accelerat(int delta)
        {
            if (carIsDead)
            {
                if (Exploded != null)
                    Exploded("Sorry? this car is dead...");
            }
            else
            {
                CurrentSpeed += delta;
                if(10 == (MaxSpeed - CurrentSpeed) && AboutToBlow != null)
                {
                    AboutToBlow("Careful buddy! Gonna blow!");
                }
                if (CurrentSpeed >= MaxSpeed)
                    carIsDead = true;
                else
                    Console.WriteLine("CurrentSpeed = {0}", CurrentSpeed);
            }
        }
    }
}
