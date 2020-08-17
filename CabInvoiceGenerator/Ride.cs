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
        /// <summary>
        /// Initializes a new instance of the <see cref="Ride"/> class.
        /// To Initialize A Newly Created Object.
        /// </summary>
        /// <param name="distance">Distance Covered.</param>
        /// <param name="time">Time Taken.</param>
        /// <param name="category">Ride Category.</param>
        public Ride(double distance, int time, Category category)
        {
            this.Distance = distance;
            this.Time = time;
            this.Category = category;
        }

        /// <summary>
        /// Gets or sets Distance Of Ride.
        /// </summary>
        public double Distance { get; set; }

        /// <summary>
        /// Gets or sets Ride Time Taken.
        /// </summary>
        public int Time { get; set; }

        /// <summary>
        /// Gets or sets Ride Category.
        /// </summary>
        public Category Category { get; set; }
    }
}
