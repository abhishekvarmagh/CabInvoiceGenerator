// <copyright file="CabInvoiceException.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace CabInvoiceGenerator
{
    using System;

    /// <summary>
    /// Cab Invoice Custom Exception Class.
    /// </summary>
    public class CabInvoiceException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CabInvoiceException"/> class.
        /// </summary>
        /// <param name="message">Exception Message.</param>
        public CabInvoiceException(string message)
            : base(message)
        {
        }
    }
}
