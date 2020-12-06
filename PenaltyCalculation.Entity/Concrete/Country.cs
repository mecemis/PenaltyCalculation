using PenaltyCalculation.Core.Entities;
using System.Collections.Generic;
using System.Text;

namespace PenaltyCalculation.Entity.Concrete
{
    public class Country : IEntity
    {
        public int Id { get; set; }
        public virtual List<DayOfWeekend> DayOfWeekends { get; set; }
        public virtual List<LocalHoliday> LocalHolidays { get; set; }
        public int CurrencyId { get; set; }
        public virtual Currency Currency { get; set; }
        public string Name { get; set; }
    }
}
