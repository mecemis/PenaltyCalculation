using Microsoft.AspNetCore.Mvc.Rendering;
using PenaltyCalculation.Core.Utilities.Results;
using PenaltyCalculation.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculation.Business.Abstract
{
    public interface ICountryService
    {
        Task<IDataResult<Country>> GetWithHolidaysAsync(int id);
        Task<IDataResult<IEnumerable<SelectListItem>>> GetListForDropDown();
    }
}
