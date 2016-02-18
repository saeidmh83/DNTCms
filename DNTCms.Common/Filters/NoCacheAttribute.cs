﻿using System;
using System.Web.Mvc;

namespace DNTCms.Common.Filters
{
    /// <summary>
    /// Represents an attribute that is used to mark an action method whose output will not be cached.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true, AllowMultiple = false)]
    public class NoCacheAttribute : OutputCacheAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NoCacheAttribute"/> class.
        /// </summary>
        public NoCacheAttribute()
        {
            this.NoStore = true;
            // Duration = 0 by default.
            // VaryByParam = "*" by default.
        }
    }
}
