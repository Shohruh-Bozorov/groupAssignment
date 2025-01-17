﻿using System;

// Niklas, Fredrik, Shohruh

namespace GroupAssignment1
{
    public enum GrapeVariants
    {   
        CabernetSauvignon, PinotNoir, Corvina, Shiraz, Merlot, Chablis,
        Riesling, Tempranillo, Null
    }
    public enum GrapeRegions
    {
        Bordeaux, Burgundy, Veneto, Piedmonte, RiberaDelDuero,
        NapaValley, Puglia, Pfalz, Null
    }
    public struct Wine
    {
        public int? Year;                   // null = undefined
        public string Name;
        public GrapeVariants Grape;
        public GrapeRegions Region;

        /// <summary>
        /// Creates a string representing the content of the Wine struct
        /// </summary>
        /// <returns>string that can be printed out using Console.WriteLine</returns>
        public string StringToPrint()
        {
            //Your code
            string contentOfWine = $"Wine: {Name} Year: {Year} GrapeVariant: {Grape} GrapeRegion: {Region}";
            return contentOfWine;

        }

    }

    class Program
    {
        static void Main(string[] args)
        {

            const int maxNrBottles = 4;
            Wine[] myCellar = new Wine[maxNrBottles];

            Console.WriteLine($"My cellar can have maximum {maxNrBottles} bottles");

            Wine wine1 = new Wine { Year = 2000, Name = "Château Lafite Rothschild", Grape = GrapeVariants.CabernetSauvignon, Region = GrapeRegions.Bordeaux };
            bool bOK = InsertWine(myCellar, wine1);

            Wine wine2 = new Wine { Year = 2010, Name = "Domaine de la Romanée-Conti", Grape = GrapeVariants.PinotNoir, Region = GrapeRegions.Burgundy };
            bOK = InsertWine(myCellar, wine2);

            Wine wine3 = new Wine { Year = 2005, Name = "Giuseppe Quintarelli Amarone", Grape = GrapeVariants.Corvina, Region = GrapeRegions.Veneto };
            bOK = InsertWine(myCellar, wine3);

            Wine wine4 = new Wine { Year = 2008, Name = "Sierra Cantabria", Grape = GrapeVariants.Tempranillo, Region = GrapeRegions.RiberaDelDuero };
            bOK = InsertWine(myCellar, wine4);

            Wine wine5 = new Wine { Year = 1992, Name = "Screaming Eagle", Grape = GrapeVariants.CabernetSauvignon, Region = GrapeRegions.RiberaDelDuero };
            bOK = InsertWine(myCellar, wine5);

            Console.WriteLine();
            PrintWines(myCellar);

            Console.WriteLine();
            Console.WriteLine("Enter the name of the wine you want to search for: (press q or Q to quit) ");
            string input = Console.ReadLine();
            
            Console.WriteLine();
            SearchWine(myCellar,input);

            Console.WriteLine("Enter the name of the wine you want to delete: (press q or Q to quit) ");
            string input0 = Console.ReadLine();
            
            Console.WriteLine();
            DeleteWine(myCellar, input0);


        }


        /// <summary>
        /// Inserts a wine into myCellar at first available position
        /// </summary>
        /// <param name="myCellar"></param>
        /// <param name="wine"></param>
        /// <returns>true - if insertion was possible, otherwise false</returns>
      
        private static bool InsertWine(Wine[] myCellar, Wine wine)
        {   //Your code

            bool result = false;

            for (int i = 0; i < myCellar.Length; i++)
            {

                if (myCellar[i].Name == null)
                {
                    myCellar[i] = wine;
                    Console.WriteLine($"{i + 1} Added to my cellar: {myCellar[i].StringToPrint()}");

                    return true;
                }
            }

            Console.WriteLine($"Could not add to my cellar: {wine.StringToPrint()}");
            return result;

        }

        /// <summary>
        /// Print out all the wines in myCellar
        /// </summary>
        /// <param name="myCellar"></param>
        private static void PrintWines(Wine[] myCellar)
        {
            Console.WriteLine($"My cellar has {myCellar.Length} wines:");

            //Your code
            for (int bottle = 0; bottle < myCellar.Length; bottle++)
            {
                myCellar[bottle].StringToPrint();
                Console.WriteLine(myCellar[bottle].StringToPrint());
            }
        }

        /// <summary>
        /// Counts the number of bottles in myCellar. That is all items
        /// where Year is not null 
        /// </summary>
        /// <param name="myCellar"></param>
        /// <returns>Number of bottles in myCellar</returns>
        private static int NrOfBottles(Wine[] myCellar)
        {
            //Your code

            int numberOfBottles = 0;

            for (int bottle = 0; bottle < myCellar.Length; bottle++)
            {
                if (myCellar[bottle].Year != null)
                    numberOfBottles += bottle;
            }
            return numberOfBottles;
        }
        
        // Challange metoder...............................................
        private static bool SearchWine(Wine[] myCellar, string inputName) 
        {
            for (int i = 0; i < myCellar.Length; i++)
            {
                if (inputName == myCellar[i].Name)
                {
                    Console.WriteLine($"{inputName} found at index [{i}]");
                    return true;
                }

                if (inputName == "q" || inputName == "Q")
                    break;
            }
            
            return false;
        }

        private static bool DeleteWine(Wine[] myCellar, string inputName)
        {
            for (int i = 0; i < myCellar.Length; i++)
            {
                if (inputName == myCellar[i].Name)
                { 
                    myCellar[i].Name = null;
                    myCellar[i].Year = null;
                    myCellar[i].Region = GrapeRegions.Null;
                    myCellar[i].Grape = GrapeVariants.Null;

                    Console.WriteLine($"{inputName} was deleted from index [{i}] \n{myCellar[i].StringToPrint()}");
                    return true;

                }

                if (inputName == "q" || inputName == "Q")
                    break;
            }

            Console.WriteLine(inputName + " not found");
            return false;
        }


    }
} 




