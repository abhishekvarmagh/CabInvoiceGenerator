// <copyright file="InvoiceSummary.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    /// <summary>
    /// Invoice Summary Class.
    /// </summary>
    public class InvoiceSummary
    {
        public int NumberOfRides;
        public double TotalFare;
        public double AverageFare;

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
        /// Method For Equality Check.
        /// </summary>
        /// <param name="obj">Reference Of Object.</param>
        /// <returns>True Or False.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj == this)
            {
                return true;
            }

            if (this.GetType() == obj.GetType())
            {
                return true;
            }

            InvoiceSummary that = (InvoiceSummary)obj;
            return this.NumberOfRides == that.NumberOfRides &&
                this.TotalFare.CompareTo(that.TotalFare) == 0 && this.AverageFare.CompareTo(that.AverageFare) == 0;
        }
    }
}
