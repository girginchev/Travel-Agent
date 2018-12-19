namespace TravelAgent.Web.Infrastructure.Extensions
{
    using System.Text.RegularExpressions;

    public static class StringExtensions
    {
        public static string ToFriendlyUrl(this string text)
        =>  Regex.Replace(text, @"[^А-Яа-яA-Za-z0-9_\.~]+", "-").ToLower();
    }
}
