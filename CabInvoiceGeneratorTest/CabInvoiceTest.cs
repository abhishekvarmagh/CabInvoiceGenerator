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
        /// <summary>
        /// Instance Variable Of Ride Repository.
        /// </summary>
        private RideRepository rideRepository;

        /// <summary>
        /// Instance Variable Of Invoice Service.
        /// </summary>
        private InvoiceService invoiceService;

        /// <summary>
        /// Provide a common set of functions that are performed just before each test method is called.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            this.invoiceService = new InvoiceService();
            this.rideRepository = new RideRepository();
            this.invoiceService.SetRepository(this.rideRepository);
        }

        /// <summary>
        /// Given Distance And Time When Greater Than Minimum Fare Should Return Total Fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldReturnTotalFare()
        {
            Ride[] ride = { new Ride(5.0, 5, Category.Normal) };
            double totalFare = this.invoiceService.CalculateTotalFare(ride).TotalFare;
            Assert.AreEqual(55.0, totalFare);
        }

        /// <summary>
        /// Given Distance And Time When Less Than Minimum Fare Should Return Minimum Fare.
        /// </summary>
        [Test]
        public void GivenDistanceAndTime_ShouldReturnMinimumTotalFare()
        {
            Ride[] ride = { new Ride(0.1, 1, Category.Normal) };
            double totalFare = this.invoiceService.CalculateTotalFare(ride).TotalFare;
            Assert.AreEqual(5.0, totalFare);
        }

        /// <summary>
        /// Given Multiple Ride Should Return Invoice Summary.
        /// </summary>
        [Test]
        public void GivenMultipleRides_ShouldReturnInvoiceSummary()
        {
            Ride[] rides = { new Ride(2.0, 5, Category.Normal), new Ride(0.1, 1, Category.Normal) };
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
            Ride[] rides = { new Ride(2.0, 5, Category.Normal), new Ride(0.1, 1, Category.Normal) };
            this.invoiceService.AddRides(userId, rides);
            InvoiceSummary actualInvoiceSummary = this.invoiceService.GetInvoiceSummary(userId);
            InvoiceSummary exceptedInvoiceSummary = new InvoiceSummary(rides.Length, 30.0);
            Assert.AreEqual(exceptedInvoiceSummary, actualInvoiceSummary);
        }

        /// <summary>
        /// Given Given User Id And Multiple Ride With One Premium And One Normal Should Return Invoice Summary.
        /// </summary>
        [Test]
        public void GivenUserIdAndMultipleRidesWithOnePremiumAndOneNormal_ShouldReturnInvoiceSummary()
        {
            string userId = "xyz@abc.com";
            Ride[] rides = { new Ride(2.0, 5, Category.Premium), new Ride(0.1, 1, Category.Normal) };
            this.invoiceService.AddRides(userId, rides);
            InvoiceSummary actualInvoiceSummary = this.invoiceService.GetInvoiceSummary(userId);
            InvoiceSummary exceptedInvoiceSummary = new InvoiceSummary(rides.Length, 45.0);
            Assert.AreEqual(exceptedInvoiceSummary, actualInvoiceSummary);
        }

        /// <summary>
        /// Given Given User Id And Multiple Premium Ride Should Return Invoice Summary.
        /// </summary>
        [Test]
        public void GivenUserIdAndMultiplePremiumRide_ShouldReturnInvoiceSummary()
        {
            string userId = "xyz@abc.com";
            Ride[] rides = { new Ride(2.0, 5, Category.Premium), new Ride(0.1, 1, Category.Premium) };
            this.invoiceService.AddRides(userId, rides);
            InvoiceSummary actualInvoiceSummary = this.invoiceService.GetInvoiceSummary(userId);
            InvoiceSummary exceptedInvoiceSummary = new InvoiceSummary(rides.Length, 60.0);
            Assert.AreEqual(exceptedInvoiceSummary, actualInvoiceSummary);
        }
    }
}