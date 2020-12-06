using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Internal;
using PenaltyCalculation.Business.Abstract;
using PenaltyCalculation.Business.Constants;
using PenaltyCalculation.Business.ValidationRules.FluentValidation;
using PenaltyCalculation.Core.Aspects.Autofac.Validation;
using PenaltyCalculation.Core.Utilities.Results;
using PenaltyCalculation.Entity.Concrete;
using PenaltyCalculation.Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculation.Business.Concrete
{
    public class LibraryManager : ILibraryService
    {
        private readonly ICountryService _countryService;

        public LibraryManager(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [ValidationAspect(typeof(PenaltyForCalculateValidator))]
        public async Task<IDataResult<PenaltyForDetailDto>> CalculatePenalty(PenaltyForCalculateDto penaltyForCalculateDto)
        {
          
            var country = await _countryService.GetWithHolidaysAsync(penaltyForCalculateDto.CountryId);
            if (!country.Success)
                return new ErrorDataResult<PenaltyForDetailDto>(Messages.DefaultErrorMessage);            

            int businessDays = GetBusinessDays(country.Data, penaltyForCalculateDto.CheckOutDate, penaltyForCalculateDto.ReturnDate);

            decimal totalPenalty = businessDays > 10 ? CalculatePenalty(businessDays, 10, 5) : 0;

            return new SuccessDataResult<PenaltyForDetailDto>(new PenaltyForDetailDto { Currency = country.Data.Currency.Symbol, Penalty = totalPenalty, TotalBusinessDays = businessDays });
        }

    

        private decimal CalculatePenalty(int businessDays, int returnDayLimit, int penaltyAmount)
        {
            return (businessDays - returnDayLimit) * penaltyAmount;
        }

        private int GetBusinessDays(Country country, DateTime checkOutDate, DateTime returnDate)
        {
            int totalDays = (int)(returnDate - checkOutDate).TotalDays + 1;
            IEnumerable<DayOfWeek> weekends = country.DayOfWeekends.Select(x => x.Weekend);
            List<LocalHoliday> localHolidays = country.LocalHolidays;

            int holiday = 0;    //holiday count
            int i = 1;           //index of days

            for (var date = checkOutDate; date <= checkOutDate.AddDays(6); date = date.AddDays(1)) //checked first 7 days
            {
                if (weekends.Contains(date.DayOfWeek))
                {
                    holiday = holiday + (int)((totalDays - i) / 7) + 1; //if there is a holiday at i'nth index, should be (totaldays-i)/7 more
                }
                if (totalDays <= i) break; // for checking if totaldays less than 1 week
                i++;

               
              
            }

            foreach (var localHoliday in localHolidays)     
            {
                //long ranged date spans, needs to get checked if holiday is repetitive
                var tempDate = new DateTime(checkOutDate.Year - 1, localHoliday.ReferenceDate.Month, localHoliday.ReferenceDate.Day); 
                for (int k = checkOutDate.Year; k <= returnDate.Year; k++)
                {
                    tempDate = tempDate.AddYears(1);
                    
                    //holiday can be longer than 1 day
                    for (int j = 0; j < localHoliday.Length; j++)
                    {
                        tempDate = tempDate.AddDays(j);
                        //checking holiday is in range and if it is a weekend day
                        if (checkOutDate <= tempDate && returnDate >= tempDate && !weekends.Contains(tempDate.DayOfWeek))
                            holiday++;
                        tempDate = tempDate.AddDays((-1) * j);
                    }
                }
            }
            return totalDays - holiday;
        }


    }
}
