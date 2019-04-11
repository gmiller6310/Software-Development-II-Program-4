// Program 4
// CIS 200-01
// Fall 2017
// Due: 11/27/2017
// Grading ID: C6485
// Description: Explores sorting using comparers and the natural ordering of classes

// File: TestParcels.cs
// This is a simple, console application designed to exercise the Parcel hierarchy.
// It creates several different Parcels and prints them.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("  John Smith  ", "   123 Any St.   ", "  Apt. 45 ",
                "  Louisville   ", "  KY   ", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4

            Letter letter1 = new Letter(a1, a2, 3.95M);                            // Letter test objects
            Letter letter2 = new Letter(a2, a1, 4.12M);

            GroundPackage gp1 = new GroundPackage(a3, a4, 14, 10, 5, 12.5);        // Ground test objects
            GroundPackage gp2 = new GroundPackage(a2, a3, 15, 11, 6, 13.1);
            
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a3, 25, 15, 15,    // Next Day test objects
                85, 7.50M);
            NextDayAirPackage ndap2 = new NextDayAirPackage(a3, a2, 27, 17, 17,
                88, 6.50M);

            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, // Two Day test objects
                80.5, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a2, a4, 47.3, 37.9, 26.2,
                81.3, TwoDayAirPackage.Delivery.Early);

            List<Parcel> parcels;      // List of test parcels

            parcels = new List<Parcel>();

            parcels.Add(letter1); // Populate list
            parcels.Add(letter2);
            parcels.Add(gp1);
            parcels.Add(gp2);
            parcels.Add(ndap1);
            parcels.Add(ndap2);
            parcels.Add(tdap1);
            parcels.Add(tdap2);

            Console.WriteLine("Original List:"); // Writes header for output
            Console.WriteLine("====================");
            foreach (Parcel p in parcels) // Loop that takes parcels in the created list and writes each one to console
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }
            Pause(); // Program pauses execution until enter is pressed

            parcels.Sort(); // Sort - uses natural order
            Console.Out.WriteLine("Sorted list (natural order):"); // Writes out header for console
            Console.WriteLine(" ==================== ");
            foreach (Parcel parcel in parcels) // Loop that outputs each parcel in the list onto the console, now sorted
            {
                Console.WriteLine(parcel);
                Console.WriteLine("==================== ");
            }

            Pause(); // Program pauses execution until enter is pressed

            parcels.Sort(new ParcelsDescendingByDestinationZip()); // Sort - uses specified Comparer class

            Console.Out.WriteLine("Sorted list (descending by destination zip order) using Comparer:"); // Header for console
            Console.WriteLine();
            foreach (Parcel p in parcels) // Loop that outputs each parcel in the list to the console
            {
                Console.WriteLine(p);
                Console.WriteLine("==================== ");
            }

            Pause(); // Execution pauses until user hits enter

            parcels.Sort(new ParcelsByTypeAscendingAndThenByCostDescending()); // Sort - uses specified Comparer class

            Console.Out.WriteLine("Sorted list (ascending by type and then descending by cost) using Comparer:"); // Header for console
            Console.WriteLine();
            foreach (Parcel p in parcels) // Loop that outputs each parcel in the list to the console
            {
                Console.WriteLine(p);
                Console.WriteLine("==================== ");
            }
        }



        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}
