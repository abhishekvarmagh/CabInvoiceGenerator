// <copyright file="CabInvoiceTest.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGeneratorTest
{
    using CabInvoiceGenerator;
    using NUnit.Framework;

    /// <summary>
    /// Cab Invoice Test Class.
    /// </summary>
    public class CabInvoiceTest
    {
        private CabInvoicesGenerator cabInvoiceGenerator;

        /// <summary>
        /// Provide a common set of functions that are performed just before each test method is called.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.cabInvoiceGenerator = new CabInvoicesGenerator();
        }

        /// <summary>
        /// Given Distance And Time When Greater Than Minimum Fare Should Return Total Fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFare()
        {
            double distance = 5.0;
            int time = 5;
            double totalFare = this.cabInvoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(55.0, totalFare);
        }

        /// <summary>
        /// Given Distance And Time When Less Than Minimum Fare Should Return Minimum Fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldReturnMinimumTotalFare()
        {
            double distance = 0.1;
            int time = 1;
            double totalFare = this.cabInvoiceGenerator.CalculateFare(distance, time);
            Assert.AreEqual(5.0, totalFare);
        }

        /// <summary>
        /// Given Multiple Ride Should Return Invoice Summary.
        /// </summary>
        [Test]
        public void GivenMultipleRides_ShouldReturnInvoiceSummary()
        {
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) }; 
            InvoiceSummary actualInvoiceSummary = this.cabInvoiceGenerator.CalculateTotalFare(rides);
            InvoiceSummary exceptedInvoiceSummary = new InvoiceSummary(rides.Length, 30.0);
            Assert.AreEqual(exceptedInvoiceSummary, actualInvoiceSummary);
        }
    }
}