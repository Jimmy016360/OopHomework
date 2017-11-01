using System;
using System.Globalization;

namespace MyBackup
{
    /// <summary>
    /// String extension.
    /// </summary>
    public static class StringExtension
    {
        /// <summary>
        /// Convert string to title case.
        /// </summary>
        /// <returns>The title case.</returns>
        /// <param name="value">Value.</param>
        public static string ToTitleCase(this string value) {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            return textInfo.ToTitleCase(value);
        }

    }
}
