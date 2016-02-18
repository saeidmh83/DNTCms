﻿using System.Web;
using System.Web.Mvc;
using DNTCms.Common.OpenGraph.ObjectTypes;

namespace DNTCms.Common.OpenGraph
{
    /// <summary>
    /// Creates Open Graph meta tags. <see cref="OpenGraphMetadata"/> for more information.
    /// </summary>
    public static class HtmlHelperExtensions
    {
        private const string OgNamespace = "og: http://ogp.me/ns# ";
        private const string FacebookNamespace = "fb: http://ogp.me/ns/fb# ";

        /// <summary>
        /// Creates a string containing the Open Graph meta tags (Also used by Facebook). <see cref="OpenGraphMetadata"/> for more information.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="openGraphMetadata">The open graph metadata.</param>
        /// <returns>The meta tags.</returns>
        public static IHtmlString OpenGraph(this HtmlHelper htmlHelper, OpenGraphMetadata openGraphMetadata)
        {
            return openGraphMetadata;
        }

        /// <summary>
        /// Creates a <see cref="string"/> representing the Open Graph, Facebook and object namespaces. The namespaces are added to the HTML head element.
        /// </summary>
        /// <param name="htmlHelper">The HTML helper.</param>
        /// <param name="openGraphMetadata">The open graph metadata.</param>
        /// <returns>The Open Graph namespaces.</returns>
        public static IHtmlString OpenGraphNamespace(this HtmlHelper htmlHelper, OpenGraphMetadata openGraphMetadata)
        {
            string prefix;
            if ((openGraphMetadata.FacebookAdministrators == null) && 
                (openGraphMetadata.FacebookApplicationId == null) &&
                (openGraphMetadata.FacebookProfileId == null))
            {
                prefix = "prefix=\"" + OgNamespace + openGraphMetadata.Namespace + "\"";
            }
            else
            {
                prefix = "prefix=\"" + OgNamespace + FacebookNamespace + openGraphMetadata.Namespace + "\"";
            }

            return new MvcHtmlString(prefix);
        }
    }
}
