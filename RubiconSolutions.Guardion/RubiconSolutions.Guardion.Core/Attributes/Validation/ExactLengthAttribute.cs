using RubiconSolutions.Guardion.Core.Enums;

namespace RubiconSolutions.Guardion.Core.Attributes.Validation
{
    /// <summary>
    /// Specifies that a string property or field must have exactly the defined number of characters.
    /// Use this attribute to enforce exact length validation on a property or field.
    /// </summary>
    [AttributeUsage((AttributeTargets.Property | AttributeTargets.Field), AllowMultiple = false, Inherited = false)]
    public class ExactLengthAttribute : Attribute
    {
        /// <summary>
        /// Gets the exact length that the string must have.
        /// </summary>
        public Int32 Length { get; init; }

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
        /// Initializes a new instance of the <see cref="ExactLengthAttribute"/> class
        /// with the specified length, field name, error severity, and optional message and suggested value.
        /// </summary>
        /// <param name="length">The exact number of characters the string must have. Must be greater than zero.</param>
        /// <param name="name">The name of the field or unit being validated.</param>
        /// <param name="errorSeverity">The severity level of the validation error.</param>
        /// <param name="message">Optional custom error message. If null or empty, a default message is generated.</param>
        /// <param name="suggestedValue">Optional suggested value to correct the input.</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if <paramref name="length"/> is zero or negative.</exception>
        /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is null or empty.</exception>
        public ExactLengthAttribute(
            Int32 length,
            String name,
            ErrorSeverity errorSeverity,
            String? message = null,
            String? suggestedValue = null)
        {
            if (length <= 0)
                throw new ArgumentOutOfRangeException(nameof(length), length, "Length must be greater than zero!");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty!", nameof(name));

            Length = length;
            Name = name;
            ErrorSeverity = errorSeverity;
            Message = string.IsNullOrWhiteSpace(message)
                ? $"{Name} field must be exactly {Length} characters long!"
                : message;
            SuggestedValue = suggestedValue;
        }
    }
}
