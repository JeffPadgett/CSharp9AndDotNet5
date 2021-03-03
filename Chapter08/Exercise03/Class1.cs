using System;
using System.Globalization;
using Humanizer;

namespace ExtensionsForPractice
{

    public static class IntExtensions
    {
        public static string Towards(this int num)
        {
            CultureInfo culture = CultureInfo.CurrentCulture;
            var result = num.ToWords(culture);
            return $"{result:N0}";
        }

        
    }

}
