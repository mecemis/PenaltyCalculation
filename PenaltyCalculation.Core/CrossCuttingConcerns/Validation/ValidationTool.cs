using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace PenaltyCalculation.Core.CrossCuttingConcerns.Validation
{
    public static class ValidationTool
    {
        public static void Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity); //9.0 dan itibaren eklenmesi gerekli
            var result = validator.Validate(context);
            if (!result.IsValid)
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
