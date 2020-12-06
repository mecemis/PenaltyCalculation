using PenaltyCalculation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PenaltyCalculation.Entity.Concrete
{
    public class LocalHoliday : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }
        public int Length { get; set; }
        public DateTime ReferenceDate { get; set; }
    }
}
