using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PenaltyCalculation.Core.DataAccess.EntityFramework;
using PenaltyCalculation.DataAccess.Abstract;
using PenaltyCalculation.DataAccess.Concrete.EntityFramework.Contexts;
using PenaltyCalculation.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculation.DataAccess.Concrete.EntityFramework
{
    public class EfCountryDal : EfEntityRepositoryBase<Country, BookPenaltyDbContext>, ICountryDal
    {
        public async Task<IEnumerable<SelectListItem>> GetListForDropDown()
        {
            using (var context = new BookPenaltyDbContext())
            {
                var countries = await context.Countries.Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToListAsync();
                return countries;
            }
        }
    }
}
