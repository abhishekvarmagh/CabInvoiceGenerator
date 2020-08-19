// <copyright file="InvoiceService.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System.Text.RegularExpressions;

    /// <summary>
    /// Cab Invoice Generator Class.
    /// </summary>
    public class InvoiceService
    {
        /// <summary>
        /// Reference Variable Of Ride Repository.
        /// </summary>
        private RideRepository rideRepository;

        /// <summary>
        /// To Set Value Of Ride Repository.
        /// </summary>
        /// <param name="rideRepository">Value Of Ride Repository.</param>
        public void SetRepository(RideRepository rideRepository)
        {
            this.rideRepository = rideRepository;
        }

        /// <summary>
        /// Function To Calculate Total Fare.
        /// </summary>
        /// <param name="rides">Multiple Rides.</param>
        /// <returns>Invoice Summary Of Ride.</returns>
        public InvoiceSummary CalculateTotalFare(Ride[] rides)
        {
            double totaFare = 0.0;
            foreach (Ride ride in rides)
            {
                totaFare += ride.Category.CalculateCostOfCabRide(ride);
            }

            return new InvoiceSummary(rides.Length, totaFare);
        }

        /// <summary>
        /// Function To Add Rides With User Id.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <param name="rides">Array Of Rides.</param>
        public void AddRides(string userId, Ride[] rides)
        {
            if (!Regex.IsMatch(userId, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,})+)$", RegexOptions.IgnoreCase))
            {
                throw new CabInvoiceException("Invalid User Identification Format.");
            }

            this.rideRepository.AddRides(userId, rides);
        }

        /// <summary>
        /// Function To Get Invoice Summary Of Particular User Id.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <returns>Invoice Summary.</returns>
        public InvoiceSummary GetInvoiceSummary(string userId)
        {
            return this.CalculateTotalFare(this.rideRepository.GetRide(userId));
        }
    }
}
