// <copyright file="Ride.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    /// <summary>
    /// Ride Class.
    /// </summary>
    public class Ride
    {
        public double Distance;
        public int Time;

        /// <summary>
        /// Initializes a new instance of the <see cref="Ride"/> class.
        /// To Initialize A Newly Created Object.
        /// </summary>
        /// <param name="distance">Distance.</param>
        /// <param name="time">Time.</param>
        public Ride(double distance, int time)
        {
            this.Distance = distance;
            this.Time = time;
        }
    }
}
