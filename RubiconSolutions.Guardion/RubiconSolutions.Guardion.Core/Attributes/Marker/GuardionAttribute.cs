namespace RubiconSolutions.Guardion.Core.Attributes.Marker
{
    /// <summary>
    /// Indicates that a property or field can be validated by the Guiardion validation engine.
    /// Use this attribute to mark members that should be checked for correctness.
    /// </summary>
    [AttributeUsage((AttributeTargets.Property | AttributeTargets.Field), AllowMultiple = false, Inherited = false)]
    public class GuardionAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets a value indicating whether the property or field should be validated.
        /// Default is <c>true</c>. 
        /// Set to <c>false</c> to skip validation for this member.
        /// </summary>
        public Boolean Enabled { get; set; } = true;

        /// <summary>
        /// Initializes a new instance of the <see cref="GuardionAttribute"/> class
        /// with <see cref="Enabled"/> set to <c>true</c> by default.
        /// </summary>
        public GuardionAttribute()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GuardionAttribute"/> class
        /// specifying whether the member should be validated.
        /// </summary>
        /// <param name="enabled">
        /// A boolean value indicating whether validation should be applied.
        /// Set <c>true</c> to validate, <c>false</c> to skip validation.
        /// </param>
        public GuardionAttribute(Boolean enabled)
        {
            Enabled = enabled;
        }
    }
}
