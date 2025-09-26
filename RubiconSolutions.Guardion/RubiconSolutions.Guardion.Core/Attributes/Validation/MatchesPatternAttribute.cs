using RubiconSolutions.Guardion.Core.Enums;

namespace RubiconSolutions.Guardion.Core.Attributes.Validation
{
    /// <summary>
    /// Specifies that a string property or field must match the given regular expression pattern.
    /// Use this attribute to enforce pattern-based validation on string fields.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class MatchesPatternAttribute : Attribute
    {
        /// <summary>
        /// Gets the regex pattern that the string must match.
        /// </summary>
        public String Pattern { get; init; }

        /// <summary>
        /// Gets the name of the property or field being validated.
        /// </summary>
        public String Name { get; init; }

        /// <summary>
        /// Gets the severity level of the validation error.
        /// </summary>
        public ErrorSeverity ErrorSeverity { get; init; }

        /// <summary>
        /// Gets the validation message to display if the string does not match the pattern.
        /// </summary>
        public String Message { get; init; }

        /// <summary>
        /// Gets an optional suggested value to help correct invalid input.
        /// </summary>
        public String? SuggestedValue { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MatchesPatternAttribute"/> class.
        /// </summary>
        /// <param name="pattern">The regular expression pattern that the string must match. Cannot be null or empty.</param>
        /// <param name="name">The name of the property or field being validated. Cannot be null or empty.</param>
        /// <param name="errorSeverity">The severity level of the validation error.</param>
        /// <param name="message">Optional custom error message. If null or empty, a default message is generated.</param>
        /// <param name="suggestedValue">Optional suggested value to correct the input.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="pattern"/> or <paramref name="name"/> is null or empty.</exception>
        public MatchesPatternAttribute(
            String pattern,
            String name,
            ErrorSeverity errorSeverity,
            String? message = null,
            String? suggestedValue = null)
        {
            if (String.IsNullOrWhiteSpace(pattern))
                throw new ArgumentException("Pattern cannot be null or empty.", nameof(pattern));

            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));

            Pattern = pattern;
            Name = name;
            ErrorSeverity = errorSeverity;
            Message = String.IsNullOrWhiteSpace(message)
                ? $"{Name} must match the pattern: {Pattern}"
                : message;
            SuggestedValue = suggestedValue;
        }
    }
}
