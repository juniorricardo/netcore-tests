using System.ComponentModel.DataAnnotations;
using static System.String;

namespace Poke.API.Models
{
    [ValidateRequest]
    public class Request
    {
        //[CustomValidation(typeof(Validation), "OrderIsRequired")]
        //public string Order { get; set; }

        //[CustomValidation(typeof(Validation), "OffSetIsRequired")]
        public string OffSet { get; set; }
        public string PartA { get; set; }
        public string PartB { get; set; }
    }

    public static class Validation
    {
        public static ValidationResult OrderIsRequired(object input)
        {
            return input == null ? new ValidationResult("The Order field is required.") :
                IsNullOrEmpty(input.ToString()) ? new ValidationResult("The Order field is required.") :
                ValidationResult.Success;
        }

        public static ValidationResult OffSetIsRequired(object input)
        {
            return input == null ? new ValidationResult("The OffSet field is required.") :
                IsNullOrEmpty(input.ToString()) ? new ValidationResult("The OffSet field is required.") :
                ValidationResult.Success;
        }
    }

    public class ValidateRequest : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            var request = (Request) validationContext.ObjectInstance;
            if (!IsNullOrEmpty(request.OffSet) || !IsNullOrEmpty(request.PartA) || !IsNullOrEmpty(request.PartB))
            {
                if (!IsNullOrEmpty(request.OffSet))
                {
                    if (!IsNullOrEmpty(request.PartA) || !IsNullOrEmpty(request.PartB))
                        return new ValidationResult("Inset only, 'Order' or 'PartA' and 'PartB'");

                    return ValidationResult.Success;
                }

                if (!IsNullOrEmpty(request.PartA))
                    return !IsNullOrEmpty(request.PartB)
                        ? ValidationResult.Success
                        : new ValidationResult("The field 'PartB', is required.");

                return new ValidationResult("The field 'PartA', is required.");
            }

            return new ValidationResult("Need input field.");
        }
    }


    public class Model
    {
        [CustomValidation(typeof(MyCustomValidation),
            "IsNotAnApple")]
        public string FavoriteFruit { get; set; }
    }

    public static class MyCustomValidation
    {
        public static ValidationResult IsNotAnApple(object input)
        {
            var result = ValidationResult.Success;

            if (input?.ToString()
                    ?.ToUpperInvariant() ==
                "APPLE")
                result = new ValidationResult("Apples are not allowed.");

            return result;
        }
    }
}