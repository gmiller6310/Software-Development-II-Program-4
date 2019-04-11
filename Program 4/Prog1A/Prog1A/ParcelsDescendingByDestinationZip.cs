// Program 4
// CIS 200-01
// Fall 2017
// Due:11/24/2017
// Grading ID: C6485
// Description: Explores sorting using comparers and the natural ordering of classes

// File: ParcelsDescendingByDestinationZip.cs
// Uses Comparer to sort parcels by destination address zip codes

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class ParcelsDescendingByDestinationZip : Comparer<Parcel>
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

            return (-1) * parcel1.DestinationAddress.Zip.CompareTo(parcel2.DestinationAddress.Zip); // Reverses natural order, so descending
        }

    }
}
