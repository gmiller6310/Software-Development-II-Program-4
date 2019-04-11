// Program 4
// CIS 200-01
// Fall 2017
// Due:11/24/2017
// Grading ID: C6485
// Description: Explores sorting using comparers and the natural ordering of classes

// File: ParcelsByTypeAscendingAndThenByCostDescending.cs
// Uses Comparer to sort parcels by type ascending and then by cost descending

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class ParcelsByTypeAscendingAndThenByCostDescending : Comparer<Parcel>
    {
        // Precondition:  None
        // Postcondition: Reverses natural parcel zip order, so descending
        //                When parcel1 < parcel2, method returns positive #
        //                When parcel1 == parcel2, method returns zero
        //                When parcel1 > parcel2, method returns negative #
        public override int Compare(Parcel parcel1, Parcel parcel2)
        {
            // Ensure correct handling of null values (in .NET, null less than anything)
            if (parcel1 == null && parcel2 == null) // Both null?
                return 0;                 // Equal

            if (parcel1 == null) // only parcel1 is null?
                return -1;  // null is less than any actual parcel

            if (parcel2 == null) // only parcel2 is null?
                return 1;   // Any actual parcel is greater than null

            if (parcel1.GetType().ToString().CompareTo(parcel2.GetType().ToString()) != 0) // Compares the types of inputs, as long as not 0 moves on?
            {
                return parcel1.GetType().ToString().CompareTo(parcel2.GetType().ToString()); // Compares inputs types and puts in ascending order
            }
            else
            {
                return (-1) * parcel1.CalcCost().CompareTo(parcel2.CalcCost()); // Compares costs of inputs and puts in descending order
            }
        }
    }
}
