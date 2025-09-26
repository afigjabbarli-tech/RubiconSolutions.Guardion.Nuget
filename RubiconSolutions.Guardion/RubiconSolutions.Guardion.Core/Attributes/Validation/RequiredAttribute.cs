using RubiconSolutions.Guardion.Core.Enums;

namespace RubiconSolutions.Guardion.Core.Attributes.Validation
{
    /// <summary>
    /// Indicates that a property or field is required and must not be null (for reference types)
    /// or equal to its default value (for value types).
    /// Use this attribute to enforce mandatory fields in your models.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = false)]
    public class RequiredAttribute : Attribute
    {
        /// <summary>
        /// Gets the name of the property or field being validated.
        /// Used in validation messages and logging.
        /// </summary>
        public String Name { get; init; }

        /// <summary>
        /// Gets the severity level of the validation error.
        /// </summary>
        public ErrorSeverity ErrorSeverity { get; init; }

        /// <summary>
        /// Gets the validation message that will be displayed if validation fails.
        /// </summary>
        public String Message { get; init; }

        /// <summary>
        /// Gets an optional suggested value to help correct invalid input.
        /// </summary>
        public String? SuggestedValue { get; init; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RequiredAttribute"/> class
        /// with the specified property name, error severity, optional message, and optional suggested value.
        /// </summary>
        /// <param name="name">The name of the property or field being validated. Cannot be null or empty.</param>
        /// <param name="errorSeverity">The severity level of the validation error.</param>
        /// <param name="message">Optional custom error message. If null or empty, a default message is generated.</param>
        /// <param name="suggestedValue">Optional suggested value to correct the input.</param>
        /// <exception cref="ArgumentException">Thrown if <paramref name="name"/> is null or empty.</exception>
        public RequiredAttribute(
            String name,
            ErrorSeverity errorSeverity,
            String? message = null,
            String? suggestedValue = null)
        {
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));

            Name = name;
            ErrorSeverity = errorSeverity;
            Message = String.IsNullOrWhiteSpace(message)
                ? $"{Name} is required and cannot be null or default value."
                : message;
            SuggestedValue = suggestedValue;
        }
    }
}
