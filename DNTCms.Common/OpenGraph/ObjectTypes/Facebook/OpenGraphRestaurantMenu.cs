﻿using System;
using System.Collections.Generic;
using System.Text;
using DNTCms.Common.Extentions;
using DNTCms.Common.OpenGraph.Enums;
using DNTCms.Common.OpenGraph.Media;

namespace DNTCms.Common.OpenGraph.ObjectTypes.Facebook
{
    /// <summary>
    /// This object type represents a restaurant's menu. A restaurant can have multiple menus, and each menu has multiple sections.
    /// This object type is not part of the Open Graph standard but is used by Facebook.
    /// See https://developers.facebook.com/docs/reference/opengraph/object-type/restaurant.menu/
    /// </summary>
    public class OpenGraphRestaurantMenu : OpenGraphMetadata
    {
        private readonly string _restaurantUrl;

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGraphRestaurantMenu" /> class.
        /// </summary>
        /// <param name="title">The title of the object as it should appear in the graph.</param>
        /// <param name="image">The default image.</param>
        /// <param name="restaurantUrl">The URL to the page about the restaurant who wrote the menu. This URL must contain profile meta tags <see cref="OpenGraphResteraunt"/>.</param>
        /// <param name="url">The canonical URL of the object, used as its ID in the graph.</param>
        /// <exception cref="System.ArgumentNullException">location is <c>null</c>.</exception>
        public OpenGraphRestaurantMenu(string title, OpenGraphImage image, string restaurantUrl, string url = null)
            : base(title, image, url)
        {
            if (restaurantUrl == null)
            {
                throw new ArgumentNullException("restaurantUrl");
            }

            this._restaurantUrl = restaurantUrl;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the namespace of this open graph type.
        /// </summary>
        public override string Namespace { get { return "restaurant: http://ogp.me/ns/restaurant#"; } }

        /// <summary>
        /// Gets the URL to the page about the restaurant who wrote the menu. This URL must contain profile meta tags <see cref="OpenGraphResteraunt"/>.
        /// </summary>
        public string RestaurantUrl { get { return this._restaurantUrl; } }

        /// <summary>
        /// Gets or sets the URL's to the pages about the menu sections. This URL must contain restaurant.section meta tags <see cref="OpenGraphResterauntMenuSection"/>.
        /// </summary>
        public IEnumerable<string> SectionUrls { get; set; }

        /// <summary>
        /// Gets the type of your object. Depending on the type you specify, other properties may also be required.
        /// </summary>
        public override OpenGraphType Type { get { return OpenGraphType.RestaurantMenu; } }

        #endregion

        #region Public Methods

        /// <summary>
        /// Appends a HTML-encoded string representing this instance to the <paramref name="stringBuilder"/> containing the Open Graph meta tags.
        /// </summary>
        /// <param name="stringBuilder">The string builder.</param>
        public override void ToString(StringBuilder stringBuilder)
        {
            base.ToString(stringBuilder);

            stringBuilder.AppendMetaPropertyContent("restaurant:restaurant", this.RestaurantUrl);

            if (this.SectionUrls != null)
            {
                foreach (var sectionUrl in this.SectionUrls)
                {
                    stringBuilder.AppendMetaPropertyContent("restaurant:section", sectionUrl);
                }
            }
        }

        #endregion
    }
}
