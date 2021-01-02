using FluentValidation;

namespace CloudNDevOps.TerraformAgentDbor.Contracts.Validations
{
    /// <summary>
    /// Defines Validators related to <see cref="ColumnDefinition"/>
    /// </summary>
    public class ColumnDefinitionValidator : AbstractValidator<ColumnDefinition>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ColumnDefinitionValidator()
        {
            RuleFor(cd => cd.Name)
                .MinimumLength(1)
                .MaximumLength(128);
        }
    }
}
