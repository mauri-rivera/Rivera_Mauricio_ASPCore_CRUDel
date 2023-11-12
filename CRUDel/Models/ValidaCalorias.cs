using System.ComponentModel.DataAnnotations;

namespace CRUDel.Models
{
    public class ValidaCaloriasAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
            {
                return new ValidationResult("La cantidad de calorías es requerida!");
            }
            else
            {
                return ValidationResult.Success;
            }
        }
    }
}
