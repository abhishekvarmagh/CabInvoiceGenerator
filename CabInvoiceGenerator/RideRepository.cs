// <copyright file="RideRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Ride Repository Class.
    /// </summary>
    public class RideRepository
    {
        /// <summary>
        /// Dictionary To Store User Id As Key And Ride Taken By User As Value.
        /// </summary>
        private readonly Dictionary<string, List<Ride>> userRides;

        /// <summary>
        /// Initializes a new instance of the <see cref="RideRepository"/> class.
        /// To Initialize A Newly Created Object.
        /// </summary>
        public RideRepository()
        {
            this.userRides = new Dictionary<string, List<Ride>>();
        }

        /// <summary>
        /// Function To Add Ride.
        /// </summary>
        /// <param name="userId">User Id.</param>
        /// <param name="rides">Array Of Rides.</param>
        public void AddRides(string userId, Ride[] rides)
        {
            bool rideList = this.userRides.ContainsKey(userId);
            if (rideList == true)
            {
                List<Ride> list = this.userRides[userId];
                list.AddRange(rides);
                this.userRides[userId] = list;
            }
            else
            {
                this.userRides.Add(userId, new List<Ride>(rides));
            }
        }

        /// <summary>
        /// Get Ride Of Particular User Id.
        /// </summary>
        /// <param name="userId">Value Of User Id.</param>
        /// <returns>Ride Details.</returns>
        public Ride[] GetRide(string userId)
        {
            return this.userRides[userId].ToArray();
        }
    }
}
