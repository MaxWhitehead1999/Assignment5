using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

/// Name: Max Whitehead - Student ID: 0000782451


namespace Problem1
{
    class ToyFactory
    {
        public abstract class Toy
        {
            public double price;
            public string category;
            public string name;
            public string brand;
            public int yearOfManufacture;
            public int mimimumAge;
            public bool chockingHazard;
            public double weight;


            /// <summary>
            ///  abstract class Toy with properties price, category, 
            ///  name, brand, yearOfManufacture, mimimumAge, 
            ///  chockingHazard and weight
            /// </summary>
            /// <param name="price">price of toy</param>
            /// <param name="name">name of toy</param>
            /// <param name="brand">brand of toy</param>
            /// <param name="yearOfManufacture">year of manufacturing for toy</param>
            /// <param name="mimimumAge">minimum age limit</param>
            /// <param name="chockingHazard">is the toy a chocking hazard</param>
            /// <param name="weight">weight of toy</param>
            /// <param name="category">category of toy</param>
            public Toy(double price, string name, string brand,  int yearOfManufacture, int mimimumAge, bool chockingHazard, double weight , string category)
            {
                price = price;
                name = name;
                brand = brand;
                yearOfManufacture = yearOfManufacture;
                mimimumAge = mimimumAge;
                chockingHazard = chockingHazard;
                weight = weight;
                category = category;
            }

        }


        /// <summary>
        ///  Represents a toy car with properties for number of wheels,
        ///  electric status, and car type.
        /// </summary>

        public class Car : Toy
        {
            public int numberofWheels { get; set; }
            public bool isElectric { get; set; }
            public string carType { get; set; }

            public Car(double price, string name, string brand, int yearOfManufacture,
               int mimimumAge, bool chockingHazard, double weight,
               int numberofWheels, bool isElectric, string carType)
            : base(price, name, brand, yearOfManufacture, mimimumAge, chockingHazard, weight, "Car")
            {
                this.numberofWheels = numberofWheels;
                this.isElectric = isElectric;
                this.carType = carType;
            }

            public void drive()
            {
                Console.WriteLine(name + " is driving, it is a " + numberofWheels + "wheeler");
            }

            public void race()
            {
                Console.WriteLine(name + " is racing, car type " + carType);
            }

        }

        /// <summary>
        ///  Represents a toy dollhouse with properties for rooms,
        ///  furniture, and floors.
        /// </summary>
        public class Dollhouse : Toy
        {
            public int numberOfRooms { get; set; }
            public bool hasFurniture { get; set; }
            public int numberOfFloors { get; set; }
            public Dollhouse(double price, string name, string brand, int yearOfManufacture,
               int mimimumAge, bool chockingHazard, double weight,
               int numberOfRooms, bool hasFurniture, int numberOfFloors)
            : base(price, name, brand, yearOfManufacture, mimimumAge, chockingHazard, weight, "Dollhouse")
            {
                this.numberOfRooms = numberOfRooms;
                this.hasFurniture = hasFurniture;
                this.numberOfFloors = numberOfFloors;
            }

            public void play()
            {
                Console.WriteLine(name + " is being played with, it has " + numberOfRooms + " rooms with " + numberOfFloors + " Floors");
            }

            public void decorate()
            {
                Console.WriteLine(name + " is being decorated, it has " + numberOfRooms + " rooms with " + numberOfFloors + " Floors");
            }
        }

        /// <summary>
        ///  Represents a stuffed animal toy with species, accessory, 
        ///  and limb information.
        /// </summary>
        public class Stuffedanimal : Toy
        {
            public string animalspecies { get; set; }
            public string accessory { get; set; }
            public bool haslimbs { get; set; }

            public Stuffedanimal(double price, string name, string brand, int yearOfManufacture,
               int mimimumAge, bool chockingHazard, double weight,
               string animalspecies, string accessory, bool haslimbs)
                : base(price, name, brand, yearOfManufacture, mimimumAge, chockingHazard, weight, "StuffedAnimal")
            {
                this.animalspecies = animalspecies;
                this.accessory = accessory;
                this.haslimbs = haslimbs;
            }

            public void dressup()
            {
                Console.WriteLine(name + " is being dressed up with " + accessory + " accessory");
            }

            public void teaparty()
            {
                Console.WriteLine(name + " play teaparty with mr" + animalspecies);
            }

        }

        /// <summary>
        ///  represents a stacking toy with properties for number of rings,
        /// </summary>
        public class Rainbowstackers : Toy
        {
            public int numberOfRings { get; set; }
            public int maxStackHeight { get; set; }
            public bool isRingsCircular { get; set; }

            public Rainbowstackers(double price, string name, string brand, int yearOfManufacture,
               int mimimumAge, bool chockingHazard, double weight,
               int numberOfRings, int maxStackHeight, bool isRingsCircular)
                : base(price, name, brand, yearOfManufacture, mimimumAge, chockingHazard, weight, "RainbowStackers")
            {
                this.numberOfRings = numberOfRings;
                this.maxStackHeight = maxStackHeight;
                this.isRingsCircular = isRingsCircular;
            }

            public void stack()
            {
                Console.WriteLine(name + " is being stacked with " + numberOfRings + " rings and max stack height of " + maxStackHeight);
            }
             public void sort()
            {
                Console.WriteLine(name + " is being sorted with " + numberOfRings + " rings and max stack height of " + maxStackHeight);
            }
        }

    }

   

}
