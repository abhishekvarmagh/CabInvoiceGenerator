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
        private InvoiceService invoiceService;

        /// <summary>
        /// Provide a common set of functions that are performed just before each test method is called.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.invoiceService = new InvoiceService();
        }

        /// <summary>
        /// Given Distance And Time When Greater Than Minimum Fare Should Return Total Fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFare()
        {
            double distance = 5.0;
            int time = 5;
            double totalFare = this.invoiceService.CalculateFare(distance, time);
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
            double totalFare = this.invoiceService.CalculateFare(distance, time);
            Assert.AreEqual(5.0, totalFare);
        }

        /// <summary>
        /// Given Multiple Ride Should Return Invoice Summary.
        /// </summary>
        [Test]
        public void GivenMultipleRides_ShouldReturnInvoiceSummary()
        {
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) }; 
            InvoiceSummary actualInvoiceSummary = this.invoiceService.CalculateTotalFare(rides);
            InvoiceSummary exceptedInvoiceSummary = new InvoiceSummary(rides.Length, 30.0);
            Assert.AreEqual(exceptedInvoiceSummary, actualInvoiceSummary);
        }

        /// <summary>
        /// Given Given User Id And Multiple Ride Should Return Invoice Summary.
        /// </summary>
        [Test]
        public void GivenUserIdAndMultipleRides_ShouldReturnInvoiceSummary()
        {
            string userId = "xyz@abc.com";
            Ride[] rides = { new Ride(2.0, 5), new Ride(0.1, 1) };
            this.invoiceService.AddRides(userId, rides);
            InvoiceSummary actualInvoiceSummary = this.invoiceService.GetInvoiceSummary(userId);
            InvoiceSummary exceptedInvoiceSummary = new InvoiceSummary(rides.Length, 30.0);
            Assert.AreEqual(exceptedInvoiceSummary, actualInvoiceSummary);
        }
    }
}