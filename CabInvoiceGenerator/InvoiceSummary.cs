// <copyright file="InvoiceSummary.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;

    /// <summary>
    /// Invoice Summary Class.
    /// </summary>
    public class InvoiceSummary
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceSummary"/> class.
        /// To Initialize A Newly Created Object.
        /// </summary>
        /// <param name="numberOfRides">Number Of Rides.</param>
        /// <param name="totalFare">Total Fare.</param>
        public InvoiceSummary(int numberOfRides, double totalFare)
        {
            this.NumberOfRides = numberOfRides;
            this.TotalFare = totalFare;
            this.AverageFare = totalFare / numberOfRides;
        }

        /// <summary>
        /// Gets or sets Number Of Rides.
        /// </summary>
        public int NumberOfRides { get; set; }

        /// <summary>
        /// Gets or sets Total Fare Of Ride.
        /// </summary>
        public double TotalFare { get; set; }

        /// <summary>
        /// Gets or sets Average Fare Of Ride.
        /// </summary>
        public double AverageFare { get; set; }

        /// <summary>
        /// Method For Equality Check.
        /// </summary>
        /// <param name="obj">Reference Of Object.</param>
        /// <returns>True Or False.</returns>
        public override bool Equals(object obj)
        {
            InvoiceSummary that = (InvoiceSummary)obj;
            return this.NumberOfRides == that.NumberOfRides &&
                this.TotalFare.CompareTo(that.TotalFare) == 0 && this.AverageFare.CompareTo(that.AverageFare) == 0;
        }

        /// <summary>
        /// Override GetHashCode Method.
        /// </summary>
        /// <returns>Return The Hash Code Value.</returns>
        public override int GetHashCode()
        {
            return HashCode.Combine(this.NumberOfRides, this.TotalFare, this.AverageFare);
        }
    }
}
