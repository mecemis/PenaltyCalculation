using PenaltyCalculation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PenaltyCalculation.Entity.Concrete
{
    public class DayOfWeekend : IEntity
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public DayOfWeek Weekend { get; set; }
    }
}
