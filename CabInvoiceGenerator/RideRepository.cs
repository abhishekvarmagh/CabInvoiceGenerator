// <copyright file="RideRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System.Collections.Generic;

    /// <summary>
    /// Ride Repository Class.
    /// </summary>
    public class RideRepository
    {
        Dictionary<string, List<Ride>> userRides;

        /// <summary>
        /// Initializes a new instance of the <see cref="RideRepository"/> class.
        /// To Initialize A Newly Created Object.
        /// </summary>
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="rides"></param>
        public void AddRides(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            if (rideList == false)
            {
                List<Ride> list = new List<Ride>();
                list.AddRange(rides);
                this.userRides.Add(userId, list);
            }
        }

        public Ride[] GetRide(string userId)
        {
            return this.userRides[userId].ToArray();
        }
    }
}
