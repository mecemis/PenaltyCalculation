using PenaltyCalculation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PenaltyCalculation.Entity.Concrete
{
    public class Currency : IEntity
    {
        public int Id { get; set; }
        public virtual List<Country> Countries { get; set; }
        public string Shortening { get; set; }
        public string Symbol { get; set; }
    }
}
