using System.ComponentModel.DataAnnotations;

namespace PolicyMicroservice.Attributes;

public class NotDefaultGuid : ValidationAttribute
{
    public NotDefaultGuid()
        : base("{0} Is Default Guid ID, Not Valid In This Scenario")
    { }

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        return value is Guid id && Equals(Guid.Empty, id)
            ? new ValidationResult(base.FormatErrorMessage(validationContext.DisplayName))
            : ValidationResult.Success;
    }
}