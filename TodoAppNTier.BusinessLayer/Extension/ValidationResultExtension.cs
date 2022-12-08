using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TodoAppNTier.Common.ResponseObjects;

namespace TodoAppNTier.BusinessLayer.Extension
{
   public static class ValidationResultExtension
    {
        public static List<CustomValidationError> ConvertToCustomValidationError(this ValidationResult validationResult)
        {
            List<CustomValidationError> errors = new();
            foreach (var error in validationResult.Errors)
            {
                errors.Add(new()
                {
                    Errormesage = error.ErrorMessage,
                    ProperTyName = error.PropertyName
                });
            }
            return errors;
        }
    }
}
