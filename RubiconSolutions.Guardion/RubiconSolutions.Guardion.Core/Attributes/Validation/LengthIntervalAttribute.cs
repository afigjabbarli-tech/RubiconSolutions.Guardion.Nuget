using RubiconSolutions.Guardion.Core.Enums;

namespace RubiconSolutions.Guardion.Core.Attributes.Validation
{
    /// <summary>
    /// Specifies that a string property or field must have a length within a defined interval.
    /// Use this attribute to enforce minimum and maximum length validation on a property or field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class LengthIntervalAttribute : Attribute
    {
        /// <summary>
        /// Gets the minimum allowed length for the string.
        /// </summary>
        public Int32 MinLength { get; init; }

        /// <summary>
        /// Gets the maximum allowed length for the string.
        /// </summary>
        public Int32 MaxLength { get; init; }

        /// <summary>
        /// Gets the name of the field or unit being validated.
        /// Used in error messages and logging.
        /// </summary>
        public String Name { get; init; }

        /// <summary>
        /// Gets the severity level of the validation error.
        /// </summary>
        public ErrorSeverity ErrorSeverity { get; init; }

        /// <summary>
        /// Gets the validation message to be displayed if validation fails.
        /// </summary>
        public String Message { get; init; }

        /// <summary>
        /// Gets an optional suggested value that can be used to help correct the invalid input.
        /// </summary>
        public String? SuggestedValue { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="LengthIntervalAttribute"/> class
        /// with the specified min/max lengths, field name, error severity, and optional message and suggested value.
        /// </summary>
        /// <param name="minLength">Minimum allowed length. Must be greater than zero and less than or equal to <paramref name="maxLength"/>.</param>
        /// <param name="maxLength">Maximum allowed length. Must be greater than or equal to <paramref name="minLength"/>.</param>
        /// <param name="name">The name of the field or unit being validated.</param>
        /// <param name="errorSeverity">The severity level of the validation error.</param>
        /// <param name="message">Optional custom error message. If null or empty, a default message is generated.</param>
        /// <param name="suggestedValue">Optional suggested value to correct the input.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if minLength or maxLength are invalid.</exception>
        /// <exception cref="ArgumentException">Thrown if name is null or empty.</exception>
        public LengthIntervalAttribute(
            Int32 minLength,
            Int32 maxLength,
            String name,
            ErrorSeverity errorSeverity,
            String? message = null,
            String? suggestedValue = null)
        {
            if (minLength <= 0)
                throw new ArgumentOutOfRangeException(nameof(minLength), minLength, "Minimum length must be greater than zero.");

            if (maxLength < minLength)
                throw new ArgumentOutOfRangeException(nameof(maxLength), maxLength, "Maximum length must be greater than or equal to minimum length.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));

            MinLength = minLength;
            MaxLength = maxLength;
            Name = name;
            ErrorSeverity = errorSeverity;
            Message = string.IsNullOrWhiteSpace(message)
                ? $"{Name} field length must be between {MinLength} and {MaxLength} characters."
                : message;
            SuggestedValue = suggestedValue;
        }
    }
}
