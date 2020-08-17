// <copyright file="Category.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;

    /// <summary>
    /// Category Class.
    /// </summary>
    public class Category
    {
        /// <summary>
        /// Ride Of Premium Type.
        /// </summary>
        public static readonly Category Premium = new Category(15.0, 2.0, 20.0);

        /// <summary>
        /// Ride of Normal Type.
        /// </summary>
        public static readonly Category Normal = new Category(10.0, 1.0, 5.0);

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// To Initialize A Newly Created Object.
        /// </summary>
        /// <param name="costPerKilometer">Value Of Cost Per Kilometer.</param>
        /// <param name="costPerMinute">Value Of Cost Per Minute.</param>
        /// <param name="minimumFare">Value Of Minimum Fare.</param>
        public Category(double costPerKilometer, double costPerMinute, double minimumFare)
        {
            this.CostPerKilometer = costPerKilometer;
            this.CostPerMinute = costPerMinute;
            this.MinimumFare = minimumFare;
        }

        /// <summary>
        /// Gets or sets Cost Required For Per Kilometer.
        /// </summary>
        public double CostPerKilometer { get; set; }

        /// <summary>
        /// Gets or sets Cost Required For Per Minutes.
        /// </summary>
        public double CostPerMinute { get; set; }

        /// <summary>
        /// Gets or sets Cost Required For Minimum Fare.
        /// </summary>
        public double MinimumFare { get; set; }

        /// <summary>
        /// Function To Get Total Fare Of Cab Ride.
        /// </summary>
        /// <param name="ride">Object Of Ride.</param>
        /// <returns>Value Of Total Fare.</returns>
        public double CalculateCostOfCabRide(Ride ride)
        {
            double totalFare = (ride.Distance * this.CostPerKilometer) + (ride.Time * this.CostPerMinute);
            return Math.Max(totalFare, this.MinimumFare);
        }
    }
}
