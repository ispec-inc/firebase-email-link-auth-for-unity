using System;
using System.Collections.Specialized;
using System.Web;

namespace ispec.FirebaseEmailLinkAuth
{
    internal static class UrlParser
    {
        public static NameValueCollection ToUrlQueryKeyValuePears(this string urlString)
        {
            try
            {
                return HttpUtility.ParseQueryString(urlString.ToUri().Query);
            }
            catch (Exception e)
                when (e is ArgumentNullException or NullReferenceException)
            {
                return new NameValueCollection();
            }
        }

        public static Uri ToUri(this string urlString)
        {
            try
            {
                return new Uri(urlString);
            }
            catch (Exception e)
                when (e is ArgumentNullException or UriFormatException)
            {
                return null;
            }
        }
    }
}
