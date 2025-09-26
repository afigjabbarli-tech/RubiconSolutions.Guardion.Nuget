using RubiconSolutions.Guardion.Core.Enums;

namespace RubiconSolutions.Guardion.Core.Attributes.Validation
{
    /// <summary>
    /// Specifies that a string property or field must be a valid email address.
    /// Validation (regex + optional MX check) is performed by the Guardion validator engine.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class EmailWithMxAttribute : Attribute
    {
        /// <summary>
        /// Gets the name of the property or field being validated.
        /// </summary>
        public String Name { get; init; }

        /// <summary>
        /// Gets the severity level of the validation error.
        /// </summary>
        public ErrorSeverity ErrorSeverity { get; init; }

        /// <summary>
        /// Gets the validation message to display if validation fails.
        /// </summary>
        public String Message { get; init; }

        /// <summary>
        /// Gets an optional suggested value to help correct invalid input.
        /// </summary>
        public String? SuggestedValue { get; init; }

        /// <summary>
        /// Indicates whether MX record validation should be performed for the email domain.
        /// </summary>
        public Boolean CheckMxRecord { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="EmailWithMxAttribute"/> class.
        /// </summary>
        /// <param name="name">The name of the property or field being validated. Cannot be null or empty.</param>
        /// <param name="errorSeverity">The severity level of the validation error.</param>
        /// <param name="message">Optional custom error message. If null or empty, a default message is generated.</param>
        /// <param name="suggestedValue">Optional suggested value to correct the input.</param>
        /// <param name="checkMxRecord">Indicates whether MX record validation should be performed. Default is false.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is null or empty.</exception>
        public EmailWithMxAttribute(
            String name,
            ErrorSeverity errorSeverity,
            String? message = null,
            String? suggestedValue = null,
            Boolean checkMxRecord = false)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));

            Name = name;
            ErrorSeverity = errorSeverity;
            Message = String.IsNullOrWhiteSpace(message)
                ? $"{Name} must be a valid email address."
                : message;
            SuggestedValue = suggestedValue;
            CheckMxRecord = checkMxRecord;
        }
    }
}
