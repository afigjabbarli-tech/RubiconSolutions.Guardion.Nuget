using RubiconSolutions.Guardion.Core.Enums;

namespace RubiconSolutions.Guardion.Core.Attributes.Validation
{
    /// <summary>
    /// Specifies that a string property or field must not exceed a defined maximum length.
    /// Use this attribute to enforce maximum length validation on a property or field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class MaximumLengthAttribute : Attribute
    {
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
        /// Initializes a new instance of the <see cref="MaximumLengthAttribute"/> class
        /// with the specified maximum length, field name, error severity, and optional message and suggested value.
        /// </summary>
        /// <param name="maxLength">Maximum allowed length. Must be greater than zero.</param>
        /// <param name="name">The name of the field or unit being validated.</param>
        /// <param name="errorSeverity">The severity level of the validation error.</param>
        /// <param name="message">Optional custom error message. If null or empty, a default message is generated.</param>
        /// <param name="suggestedValue">Optional suggested value to correct the input.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if maxLength is less than or equal to zero.</exception>
        /// <exception cref="ArgumentException">Thrown if name is null or empty.</exception>
        public MaximumLengthAttribute(
            Int32 maxLength,
            String name,
            ErrorSeverity errorSeverity,
            String? message = null,
            String? suggestedValue = null)
        {
            if (maxLength <= 0)
                throw new ArgumentOutOfRangeException(nameof(maxLength), maxLength, "Maximum length must be greater than zero!");

            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));

            MaxLength = maxLength;
            Name = name;
            ErrorSeverity = errorSeverity;
            Message = String.IsNullOrWhiteSpace(message)
                ? $"{Name} field must not exceed {MaxLength} characters."
                : message;
            SuggestedValue = suggestedValue;
        }
    }
}
