
using FluentValidation;

namespace CloudNDevOps.TerraformAgentDbor.Contracts.Validations
{
    /// <summary>
    /// Defines Validators related to <see cref="TableDefinition"/>
    /// </summary>
    public class TableDefinitionValidator : AbstractValidator<TableDefinition>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public TableDefinitionValidator()
        {
            RuleFor(td => td.Name)
                .MinimumLength(1)
                .MaximumLength(128);

            RuleFor(td => td.Columns)
                .NotEmpty();

        }
    }
}
