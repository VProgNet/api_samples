using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace BindAndValidate.DTO
{
    public class PersonDTO : IValidatableObject
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        private bool StartWithCaps(string value)
        {
            if (!string.IsNullOrWhiteSpace(value) && value[0].Equals(value.ToUpper()[0]))
            {
                return true;
            }
            return false;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            const string message = "Value must start with capital letter";
            var result = new List<ValidationException>();
            if (!StartWithCaps(FirstName))
            {
                yield return new ValidationResult(message, new[] { nameof(FirstName) }); 
            }

            if (!StartWithCaps(LastName))
            {
                yield return new ValidationResult(message, new[] { nameof(LastName) }); 
            }
            
        }
    }
}