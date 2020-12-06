using FluentValidation;
using PenaltyCalculation.Business.Constants;
using PenaltyCalculation.Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace PenaltyCalculation.Business.ValidationRules.FluentValidation
{
    public class PenaltyForCalculateValidator : AbstractValidator<PenaltyForCalculateDto>
    {
        public PenaltyForCalculateValidator()
        {
            RuleFor(x => x.ReturnDate).GreaterThan(x => x.CheckOutDate).WithMessage(Messages.DateError);
        }
    }
}
