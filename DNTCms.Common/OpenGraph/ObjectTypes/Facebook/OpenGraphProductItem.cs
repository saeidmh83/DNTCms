﻿using System;
using System.Collections.Generic;
using System.Text;
using DNTCms.Common.Extentions;
using DNTCms.Common.OpenGraph.Enums;
using DNTCms.Common.OpenGraph.Media;
using DNTCms.Common.OpenGraph.Structs;

namespace DNTCms.Common.OpenGraph.ObjectTypes.Facebook
{
    /// <summary>
    /// This object type represents a product item. This object type is not part of the Open Graph standard but is used by Facebook.
    /// See https://developers.facebook.com/docs/reference/opengraph/object-type/product.item/
    /// </summary>
    public class OpenGraphProductItem : OpenGraphMetadata
    {
        private readonly OpenGraphAvailability _availability;
        private readonly OpenGraphCondition _condition;
        private readonly IEnumerable<OpenGraphCurrency> _prices;
        private readonly string _retailerItemId;

        #region Constructors
        
        /// <summary>
        /// Initializes a new instance of the <see cref="OpenGraphProductItem" /> class.
        /// </summary>
        /// <param name="title">The title of the object as it should appear in the graph.</param>
        /// <param name="image">The default image.</param>
        /// <param name="availability">The availability of the item, one of 'instock', 'oos', or 'pending'.</param>
        /// <param name="condition">The condition of the item, one of 'new', 'refurbished', or 'used'.</param>
        /// <param name="prices">The prices of the item.</param>
        /// <param name="retailerItemId">The retailer's ID for the item.</param>
        /// <param name="url">The canonical URL of the object, used as its ID in the graph.</param>
        /// <exception cref="System.ArgumentNullException">prices or retailerItemId is <c>null</c>.</exception>
        public OpenGraphProductItem(
            string title,
            OpenGraphImage image,
            OpenGraphAvailability availability,
            OpenGraphCondition condition,
            IEnumerable<OpenGraphCurrency> prices,
            string retailerItemId,
            string url = null)
            : base(title, image, url)
        {
            if (prices == null) { throw new ArgumentNullException("prices"); }
            if (retailerItemId == null) { throw new ArgumentNullException("retailerItemId"); }

            this._availability = availability;
            this._condition = condition;
            this._prices = prices;
            this._retailerItemId = retailerItemId;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the target age group of the item, one of 'kids' or 'adult'.
        /// </summary>
        public OpenGraphAgeGroup? AgeGroup { get; set; }

        /// <summary>
        /// Gets the availability of the item, one of 'instock', 'oos', or 'pending'.
        /// </summary>
        public OpenGraphAvailability Availability { get { return this._availability; } }

        /// <summary>
        /// Gets or sets the brand of the item or its original manufacturer.
        /// </summary>
        public string Brand { get; set; }

        /// <summary>
        /// Gets or sets the category for the item.
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Gets or sets the colour of the item.
        /// </summary>
        public string Colour { get; set; }

        /// <summary>
        /// Gets the condition of the item, one of 'new', 'refurbished', or 'used'.
        /// </summary>
        public OpenGraphCondition Condition { get { return this._condition; } }

        /// <summary>
        /// Gets or sets a time representing when the item expired (or will expire).
        /// </summary>
        public DateTime? ExpirationTime { get; set; }

        /// <summary>
        /// Gets or sets the URL to the page about the product group. This URL must contain profile meta tags <see cref="OpenGraphProductGroup"/>.
        /// </summary>
        public string GroupUrl { get; set; }

        /// <summary>
        /// Gets or sets the Global Trade Item Number (GTIN), which encompasses UPC, EAN, JAN, and ISBN.
        /// </summary>
        public string Gtin { get; set; }

        /// <summary>
        /// Gets or sets the manufacturers part number for the item.
        /// </summary>
        public string ManufacturerPartNumber { get; set; }

        /// <summary>
        /// Gets or sets a description of the material used to make the item.
        /// </summary>
        public string Material { get; set; }

        /// <summary>
        /// Gets the namespace of this open graph type.
        /// </summary>
        public override string Namespace { get { return "product: http://ogp.me/ns/product#"; } }

        /// <summary>
        /// Gets or sets a description of the pattern used on the item.
        /// </summary>
        public string Pattern { get; set; }

        /// <summary>
        /// Gets the prices of the item.
        /// </summary>
        public IEnumerable<OpenGraphCurrency> Prices { get { return this._prices; } }

        /// <summary>
        /// Gets or sets the retailer's category for the item.
        /// </summary>
        public string RetailerCategory { get; set; }

        /// <summary>
        /// Gets or sets the retailer product group ID for this item.
        /// </summary>
        public string RetailerGroupId { get; set; }

        /// <summary>
        /// Gets the retailer's ID for the item.
        /// </summary>
        public string RetailerItemId { get { return this._retailerItemId; } }

        /// <summary>
        /// Gets or sets the sale price of the item.
        /// </summary>
        public OpenGraphCurrency SalePrice { get; set; }

        /// <summary>
        /// Gets or sets the date range for which the sale price is valid.
        /// </summary>
        public OpenGraphDateTimeRange SalePriceDates { get; set; }

        /// <summary>
        /// Gets or sets the shipping cost of the item.
        /// </summary>
        public IEnumerable<OpenGraphCurrency> ShippingCost { get; set; }

        /// <summary>
        /// Gets or sets the shipping weight of the item.
        /// </summary>
        public OpenGraphQuantity ShippingWeight { get; set; }

        /// <summary>
        /// Gets or sets a size describing the item (such as 'S', 'M', 'L').
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// Gets or sets the target gender for the item.
        /// </summary>
        public OpenGraphTargetGender? TargetGender { get; set; }

        /// <summary>
        /// Gets the type of your object. Depending on the type you specify, other properties may also be required.
        /// </summary>
        public override OpenGraphType Type { get { return OpenGraphType.ProductItem; } }

        #endregion

        #region Public Methods

        /// <summary>
        /// Appends a HTML-encoded string representing this instance to the <paramref name="stringBuilder"/> containing the Open Graph meta tags.
        /// </summary>
        /// <param name="stringBuilder">The string builder.</param>
        public override void ToString(StringBuilder stringBuilder)
        {
            base.ToString(stringBuilder);

            if (this.AgeGroup.HasValue)
            {
                stringBuilder.AppendMetaPropertyContent("product:age_group", this.AgeGroup.Value.ToLowercaseString());
            }

            stringBuilder.AppendMetaPropertyContent("product:availability", this.Availability.ToLowercaseString());
            stringBuilder.AppendMetaPropertyContentIfNotNull("product:brand", this.Brand);
            stringBuilder.AppendMetaPropertyContentIfNotNull("product:category", this.Category);
            stringBuilder.AppendMetaPropertyContentIfNotNull("product:color", this.Colour);
            stringBuilder.AppendMetaPropertyContent("product:condition", this.Condition.ToLowercaseString());
            stringBuilder.AppendMetaPropertyContentIfNotNull("product:expiration_time", this.ExpirationTime);
            stringBuilder.AppendMetaPropertyContentIfNotNull("product:group_ref", this.GroupUrl);
            stringBuilder.AppendMetaPropertyContentIfNotNull("product:gtin", this.Gtin);
            stringBuilder.AppendMetaPropertyContentIfNotNull("product:mfr_part_no", this.ManufacturerPartNumber);
            stringBuilder.AppendMetaPropertyContentIfNotNull("product:material", this.Material);
            stringBuilder.AppendMetaPropertyContentIfNotNull("product:pattern", this.Pattern);

            foreach (var price in this.Prices)
            {
                stringBuilder.AppendMetaPropertyContent("product:price:amount", price.Amount);
                stringBuilder.AppendMetaPropertyContent("product:price:currency", price.Currency);
            }

            stringBuilder.AppendMetaPropertyContentIfNotNull("product:retailer_category", this.RetailerCategory);
            stringBuilder.AppendMetaPropertyContentIfNotNull("product:retailer_group_id", this.RetailerGroupId);
            stringBuilder.AppendMetaPropertyContent("product:retailer_item_id", this.RetailerItemId);

            if (this.SalePrice != null)
            {
                stringBuilder.AppendMetaPropertyContent("product:sale_price:amount", this.SalePrice.Amount);
                stringBuilder.AppendMetaPropertyContent("product:sale_price:currency", this.SalePrice.Currency);
            }

            if (this.SalePriceDates != null)
            {
                stringBuilder.AppendMetaPropertyContent("product:sale_price_dates:start", this.SalePriceDates.Start);
                stringBuilder.AppendMetaPropertyContent("product:sale_price_dates:end", this.SalePriceDates.End);
            }

            if (this.ShippingCost != null)
            {
                foreach (var shippingCost in this.ShippingCost)
                {
                    stringBuilder.AppendMetaPropertyContent("product:shipping_cost:amount", shippingCost.Amount);
                    stringBuilder.AppendMetaPropertyContent("product:shipping_cost:currency", shippingCost.Currency);
                }
            }

            if (this.ShippingWeight != null)
            {
                stringBuilder.AppendMetaPropertyContent("product:shipping_weight:value", this.ShippingWeight.Value);
                stringBuilder.AppendMetaPropertyContent("product:shipping_weight:units", this.ShippingWeight.Units);
            }

            stringBuilder.AppendMetaPropertyContentIfNotNull("product:size", this.Size);

            if (this.TargetGender.HasValue)
            {
                stringBuilder.AppendMetaPropertyContent("product:target_gender", this.TargetGender.Value.ToLowercaseString());
            }
        }

        #endregion
    }
}