using System;
using System.Collections;
using System.Web;

namespace NGO.Common.Logging
{
    /// <summary>
    /// A class represents the start of an activity, with unique identifiers.
    /// Currently supports a unique value for each http request.
    /// </summary>
    public static class Activity
    {
        // Need to gracefully handle the scenario where were aren't running within a Web Request and therefore HttpContext.Current is null
        private static Func<IDictionary> httpContextItemsGetter = () => HttpContext.Current == null ? null : HttpContext.Current.Items;

        /// <summary>
        /// Gets a activity Id as Guid.
        /// <remarks>
        /// The Guid returned as string is of format "N".
        /// </remarks>
        /// </summary>
        public static string ActivityId
        {
            get
            {
                if (httpContextItemsGetter() == null)
                {
                    return string.Empty;
                }

                if (!httpContextItemsGetter().Contains("ActivityInstance"))
                {
                    httpContextItemsGetter().Add("ActivityInstance", Guid.NewGuid().ToString("N"));
                }

                return httpContextItemsGetter()["ActivityInstance"].ToString();
            }
        }

        internal static Func<IDictionary> HttpContextItemsGetter
        {
            set { httpContextItemsGetter = value; }
        }
    }
}
