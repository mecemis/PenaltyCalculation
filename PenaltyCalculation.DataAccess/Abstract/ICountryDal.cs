using Microsoft.AspNetCore.Mvc.Rendering;
using PenaltyCalculation.Core.DataAccess;
using PenaltyCalculation.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculation.DataAccess.Abstract
{
    public interface ICountryDal : IEntityRepository<Country>
    {
        Task<IEnumerable<SelectListItem>> GetListForDropDown();
    }
}
