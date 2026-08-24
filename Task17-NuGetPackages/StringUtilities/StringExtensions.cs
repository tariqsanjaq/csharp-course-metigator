using System;
using System.Globalization;
using System.Net.Mail;
using System.Text;

namespace StringUtilities
{

    /// <summary>
    /// Extension methods for <see cref="string"/>.
    /// </summary>
    /// <remarks>
    /// Three rules make an extension method work:
    /// the class must be <c>static</c>, the method must be <c>static</c>,
    /// and the first parameter must be prefixed with <c>this</c>.
    /// A fourth rule is about visibility: the caller needs
    /// <c>using Task13_XmlDocsExtensionMethods;</c> or these methods stay invisible.
    /// <para>
    /// We extend <see cref="string"/> here rather than editing it because we don't own it —
    /// if you own the class, add a normal instance method instead.
    /// </para>
    /// </remarks>
    public static class StringExtensions
    {
        private const string Ellipsis = "...";

        /// <summary>
        /// Converts the string to title case, e.g. "hello WORLD" becomes "Hello World".
        /// </summary>
        /// <param name="value">The string to convert. May be null.</param>
        /// <returns>
        /// A title-cased, trimmed copy of <paramref name="value"/>,
        /// or <see cref="string.Empty"/> when the input is null or whitespace.
        /// </returns>
        /// <example>
        /// <code>
        /// "tariq sanjaq".ToTitleCase();   // "Tariq Sanjaq"
        /// "HELLO WORLD".ToTitleCase();    // "Hello World"
        /// </code>
        /// </example>
        public static string ToTitleCase(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            // ToLower first: TextInfo.ToTitleCase leaves fully-uppercase words
            // untouched because it assumes they are acronyms.
            string lowered = value.Trim().ToLower(CultureInfo.CurrentCulture);
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(lowered);
        }

        /// <summary>
        /// Shortens the string to at most <paramref name="maxLength"/> characters,
        /// appending "..." when text was actually cut.
        /// </summary>
        /// <param name="value">The string to shorten. May be null.</param>
        /// <param name="maxLength">
        /// The maximum length of the result, including the trailing "...".
        /// </param>
        /// <returns>
        /// The original string when it already fits, otherwise a shortened version
        /// whose total length never exceeds <paramref name="maxLength"/>.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when <paramref name="maxLength"/> is negative.
        /// </exception>
        /// <example>
        /// <code>
        /// "The quick brown fox".Truncate(10);   // "The qui..."
        /// "Short".Truncate(10);                 // "Short"
        /// </code>
        /// </example>
        public static string Truncate(this string? value, int maxLength)
        {
            if (maxLength < 0)
                throw new ArgumentOutOfRangeException(nameof(maxLength), "maxLength cannot be negative.");

            if (string.IsNullOrEmpty(value))
                return string.Empty;

            if (value.Length <= maxLength)
                return value;

            // No room for the ellipsis itself — just hard-cut.
            if (maxLength <= Ellipsis.Length)
                return value.Substring(0, maxLength);

            return value.Substring(0, maxLength - Ellipsis.Length) + Ellipsis;
        }

        /// <summary>
        /// Checks whether the string is a syntactically valid email address.
        /// </summary>
        /// <param name="value">The string to test. May be null.</param>
        /// <returns>
        /// <c>true</c> when the value parses as a single address with a dotted domain;
        /// otherwise <c>false</c>. This checks shape only — it does not verify the
        /// mailbox actually exists.
        /// </returns>
        /// <example>
        /// <code>
        /// "tariq@bestdev.com".IsValidEmail();   // true
        /// "tariq@bestdev".IsValidEmail();       // false — no dot in the domain
        /// "not an email".IsValidEmail();        // false
        /// </code>
        /// </example>
        public static bool IsValidEmail(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return false;

            string trimmed = value.Trim();

            try
            {
                MailAddress address = new MailAddress(trimmed);

                // MailAddress accepts display-name forms like "Tariq <a@b.com>",
                // so compare back to reject anything but the bare address.
                return address.Address == trimmed && address.Host.Contains('.');
            }
            catch (FormatException)
            {
                return false;
            }
            catch (ArgumentException)
            {
                return false;
            }
        }

        /// <summary>
        /// Converts the string into a lowercase, URL-friendly slug.
        /// </summary>
        /// <param name="value">The text to convert. May be null.</param>
        /// <returns>
        /// A slug containing only lowercase letters, digits and single hyphens,
        /// or <see cref="string.Empty"/> when nothing usable remains.
        /// </returns>
        /// <example>
        /// <code>
        /// "Hello World!".ToSlug();                 // "hello-world"
        /// "  C#  Course --- Task 13 ".ToSlug();    // "c-course-task-13"
        /// </code>
        /// </example>
        public static string ToSlug(this string? value)
        {
            if (string.IsNullOrWhiteSpace(value))
                return string.Empty;

            // FormD splits accented letters into base letter + accent mark,
            // so the marks can be dropped and "café" becomes "cafe".
            string normalized = value.Trim().ToLowerInvariant().Normalize(NormalizationForm.FormD);

            StringBuilder builder = new StringBuilder(normalized.Length);
            bool lastWasHyphen = false;

            foreach (char c in normalized)
            {
                UnicodeCategory category = CharUnicodeInfo.GetUnicodeCategory(c);
                if (category == UnicodeCategory.NonSpacingMark)
                    continue;   // drop the accent mark itself

                if (char.IsLetterOrDigit(c))
                {
                    builder.Append(c);
                    lastWasHyphen = false;
                }
                else if (!lastWasHyphen && builder.Length > 0)
                {
                    // Any run of separators collapses into a single hyphen.
                    builder.Append('-');
                    lastWasHyphen = true;
                }
            }

            return builder.ToString().Trim('-').Normalize(NormalizationForm.FormC);
        }
    }
}