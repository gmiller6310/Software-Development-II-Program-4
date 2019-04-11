// Program 4
// CIS 200-01
// Fall 2017
// Due:11/24/2017
// Grading ID: C6485
// Description: Explores sorting using comparers and the natural ordering of classes

// File: Parcel.cs
// Parcel serves as the abstract base class of the Parcel hierachy.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Parcel : IComparable<Parcel>
{
    // Precondition:  None
    // Postcondition: The parcel is created with the specified values for
    //                origin address and destination address
    public Parcel(Address originAddress, Address destAddress)
    {
        OriginAddress = originAddress;
        DestinationAddress = destAddress;
    }

    public Address OriginAddress
    {
        // Precondition:  None
        // Postcondition: The parcel's origin address has been returned
        get;

        // Precondition:  None
        // Postcondition: The parcel's origin address has been set to the
        //                specified value
        set;
    }

    public Address DestinationAddress
    {
        // Precondition:  None
        // Postcondition: The parcel's destination address has been returned
        get;

        // Precondition:  None
        // Postcondition: The parcel's destination address has been set to the
        //                specified value
        set;
    }

    // Precondition:  None
    // Postcondition: The parcel's cost has been returned
    public abstract decimal CalcCost();

    // Precondition:  None
    // Postcondition: When this < parcel, method returns negative #
    //                When this == parcel, method returns zero
    //                When this > parcel, method returns positive #
    public int CompareTo(Parcel parcel)
    {
        // Ensure correct handling of null values (in .NET, null less than anything)

        if (this == null && parcel == null) // Both null?
         {
            return 0;                   // Equal
         }

        if (this == null) // only this is null?
        {
             return -1;    // null is less than any actual time
        }

        if (parcel == null) // only parcel is null?
       {
            return 1;   // Any actual parcel is greater than null
       }

        else if(this.CalcCost().CompareTo(parcel.CalcCost()) != 0) // Uses CalcCost method of parcel class and CompareTo 
                                                                   // to compare the cost values of the parcels and sort
        {
            return this.CalcCost().CompareTo(parcel.CalcCost());
        }

        else
        {
            return -1;
        }
       
    }

    // Precondition:  None
    // Postcondition: A String with the parcel's data has been returned
    public override String ToString()
    {
        string NL = Environment.NewLine; // NewLine shortcut

        return $"Origin Address:{NL}{OriginAddress}{NL}{NL}Destination Address:{NL}" +
            $"{DestinationAddress}{NL}Cost: {CalcCost():C}";
    }
}
