// <copyright file="CabInvoicesGenerator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;

    /// <summary>
    /// Cab Invoice Generator Class.
    /// </summary>
    public class InvoiceService
    {
        private static readonly double CostPerKilometer = 10.0;
        private static readonly double CostPerMinute = 1.0;
        private static readonly double MinimumFare = 5.0;
        private double totalFare = 0.0;
        private RideRepository rideRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceService"/> class.
        /// To Initialize A Newly Created Object.
        /// </summary>
        public InvoiceService()
        {
            this.rideRepository = new RideRepository();
        }

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
        public InvoiceSummary CalculateTotalFare(Ride[] rides)
        {
            double totaFare = 0.0;
            foreach (Ride ride in rides)
            {
                totaFare += this.CalculateFare(ride.Distance, ride.Time);
            }

            return new InvoiceSummary(rides.Length, totaFare);
        }

        /// <summary>
        /// Function To Add Rides With User Id.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <param name="rides">Rides.</param>
        public void AddRides(string userId, Ride[] rides)
        {
            this.rideRepository.AddRides(userId, rides);
        }

        /// <summary>
        /// Function To Get Invoice Summmary Of Particular User Id.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <returns>Invoice Summary.</returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            return this.CalculateTotalFare(this.rideRepository.GetRide(userId));
        }
    }
}
