using Microsoft.AspNetCore.Mvc.Rendering;
using PenaltyCalculation.Business.Abstract;
using PenaltyCalculation.Core.Utilities.Results;
using PenaltyCalculation.DataAccess.Abstract;
using PenaltyCalculation.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculation.Business.Concrete
{
    public class CountryManager : ICountryService
    {
        private readonly ICountryDal _countryDal;

        public CountryManager(ICountryDal countryDal)
        {
            _countryDal = countryDal;
        }

        public async Task<IDataResult<IEnumerable<SelectListItem>>> GetListForDropDown()
        {
            return new SuccessDataResult<IEnumerable<SelectListItem>> (await _countryDal.GetListForDropDown());
        }

        public async Task<IDataResult<Country>> GetWithHolidaysAsync(int id)
        {
            return new SuccessDataResult<Country>(await _countryDal.GetAsync(x => x.Id == id, includeProperties: "DayOfWeekends,LocalHolidays,Currency"));
        }
    }
}
