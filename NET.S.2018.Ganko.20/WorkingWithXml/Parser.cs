using System;
using System.Linq;
using WorkingWithXml.Entities;
using WorkingWithXml.Interfaces;
using System.Collections.Generic;

namespace WorkingWithXml
{
    /// <summary>
    /// Parser class
    /// </summary>
    /// <seealso cref="UrlAddress" />
    public sealed class Parser : IParser<string, UrlAddress>
    {
        /// <summary>
        /// Parses the specified URL.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Returns instance of UrlAddress</returns>
        /// <exception cref="ArgumentNullException">Throws when url is null or empty</exception>
        public UrlAddress Parse(string url)
        {
            if (string.IsNullOrWhiteSpace(url))
            {
                throw new ArgumentNullException($"Argument {nameof(url)} is null or empty");
            }

            if (Uri.TryCreate(url, UriKind.Absolute, out Uri uri) 
                  && (uri.Scheme == Uri.UriSchemeHttps || uri.Scheme == Uri.UriSchemeHttp))
            {
                var urlAddress = new UrlAddress();

                urlAddress.Scheme = uri.Scheme;
                urlAddress.Host = uri.Host;

                if (uri.Segments.Length > 0)
                {
                    urlAddress.Segments = uri.Segments.Skip(1).ToList();
                }
                else
                {
                    urlAddress.Segments = null;
                }

                if (uri.Query.Length > 0)
                {
                    var parameters = new string(uri.Query.Skip(1).ToArray()).Split('&');

                    foreach (var parameter in parameters)
                    {
                        var key = parameter.TakeWhile(c => c != '=').ToArray();
                        var value = parameter.SkipWhile(c => c != '=').Skip(1).ToArray();
                        var keyValue = new KeyValuePair<string, string>(new string(key), new string(value));
                        urlAddress.Parameters.Add(keyValue);
                    }
                }
                else
                {
                    urlAddress.Parameters = null;
                }

                return urlAddress;
            }

            return null;
        }
    }
}
