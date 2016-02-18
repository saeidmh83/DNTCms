﻿using System;

namespace DNTCms.Common.OpenGraph.Structs
{
    /// <summary>
    /// A set of contact information, including address, phone, email, fax and website.
    /// </summary>
    public class OpenGraphContactData
    {
        private readonly string _country;
        private readonly string _locality;
        private readonly string _postalCode;
        private readonly string _streetAddress;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGraphContactData" /> class.
        /// </summary>
        /// <param name="streetAddress">The number and street of the postal address for this business.</param>
        /// <param name="locality">The city (or locality) line of the postal address for this business.</param>
        /// <param name="postalCode">The postcode (or ZIP code) of the postal address for this business</param>
        /// <param name="country">The country of the postal address for this business.</param>
        /// <exception cref="System.ArgumentNullException">streetAddress or locality or postalCode or country is <c>null.</c>.</exception>
        public OpenGraphContactData(string streetAddress, string locality, string postalCode, string country)
        {
            if (streetAddress == null) { throw new ArgumentNullException("streetAddress"); }
            if (locality == null) { throw new ArgumentNullException("locality"); }
            if (postalCode == null) { throw new ArgumentNullException("postalCode"); }
            if (country == null) { throw new ArgumentNullException("country"); }

            this._country = country;
            this._locality = locality;
            this._postalCode = postalCode;
            this._streetAddress = streetAddress;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the country of the postal address for this business.
        /// </summary>
        public string Country { get { return this._country; } }

        /// <summary>
        /// Gets or sets the email address to contact this business.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets a fax number to contact this business.
        /// </summary>
        public string Fax { get; set; }

        /// <summary>
        /// Gets the city (or locality) line of the postal address for this business.
        /// </summary>
        public string Locality { get { return this._locality; } }

        /// <summary>
        /// Gets or sets a telephone number to contact this business.
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets the postcode (or ZIP code) of the postal address for this business.
        /// </summary>
        public string PostalCode { get { return this._postalCode; } }

        /// <summary>
        /// Gets or sets the state (or region) line of the postal address for this business.
        /// </summary>
        public string Region { get; set; }

        /// <summary>
        /// Gets the number and street of the postal address for this business.
        /// </summary>
        public string StreetAddress { get { return this._streetAddress; } }

        /// <summary>
        /// Gets or sets a website for this business.
        /// </summary>
        public string Website { get; set; }

        #endregion
    }
}
