// <copyright file="CabInvoicesGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;

    /// <summary>
    /// Cab Invoice Generator Class.
    /// </summary>
    public class CabInvoicesGenerator
    {
        private static readonly double CostPerKilometer = 10.0;
        private static readonly double CostPerMinute = 1.0;
        private static readonly double MinimumFare = 5.0;
        private double totalFare = 0.0;

        /// <summary>
        /// Function To Calculate Fare.
        /// </summary>
        /// <param name="distance">Distance.</param>
        /// <param name="time">Time.</param>
        /// <returns>Total Fare For Specific Ride.</returns>
        public double CalculateFare(double distance, int time)
        {
            this.totalFare = (distance * CostPerKilometer) + (time * CostPerMinute);
            return Math.Max(this.totalFare, MinimumFare);
        }

        /// <summary>
        /// Fuction To Calculate Total Fare.
        /// </summary>
        /// <param name="rides">Multiple Rides.</param>
        /// <returns>Total Fare For Mutiple Ride.</returns>
        public double CalculateTotalFare(Ride[] rides)
        {
            double totaFare = 0.0;
            foreach (Ride ride in rides)
            {
                totaFare += this.CalculateFare(ride.Distance, ride.Time);
            }

            return totaFare;
        }
    }
}
