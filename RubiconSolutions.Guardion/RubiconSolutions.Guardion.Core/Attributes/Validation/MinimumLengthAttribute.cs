using RubiconSolutions.Guardion.Core.Enums;

namespace RubiconSolutions.Guardion.Core.Attributes.Validation
{
    /// <summary>
    /// Specifies that a string property or field must have at least a defined minimum length.
    /// Use this attribute to enforce minimum length validation on a property or field.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class MinimumLengthAttribute : Attribute
    {
        /// <summary>
        /// Gets the minimum allowed length for the string.
        /// </summary>
        public Int32 MinLength { get; init; }

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
        /// Initializes a new instance of the <see cref="MinimumLengthAttribute"/> class
        /// with the specified minimum length, field name, error severity, and optional message and suggested value.
        /// </summary>
        /// <param name="minLength">Minimum allowed length. Must be greater than zero.</param>
        /// <param name="name">The name of the field or unit being validated.</param>
        /// <param name="errorSeverity">The severity level of the validation error.</param>
        /// <param name="message">Optional custom error message. If null or empty, a default message is generated.</param>
        /// <param name="suggestedValue">Optional suggested value to correct the input.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if minLength is less than or equal to zero.</exception>
        /// <exception cref="ArgumentException">Thrown if name is null or empty.</exception>
        public MinimumLengthAttribute(
            Int32 minLength,
            String name,
            ErrorSeverity errorSeverity,
            String? message = null,
            String? suggestedValue = null)
        {
            if (minLength <= 0)
                throw new ArgumentOutOfRangeException(nameof(minLength), minLength, "Minimum length must be greater than zero!");

            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));

            MinLength = minLength;
            Name = name;
            ErrorSeverity = errorSeverity;
            Message = String.IsNullOrWhiteSpace(message)
                ? $"{Name} field must be at least {MinLength} characters long."
                : message;
            SuggestedValue = suggestedValue;
        }
    }
}
