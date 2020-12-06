using PenaltyCalculation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PenaltyCalculation.Entity.Dtos
{
    public class PenaltyForDetailDto : IDto
    {

        private decimal penalty;

        public decimal Penalty
        {
            get { return Math.Round(penalty, 2); }
            set { penalty = value; }
        }

        public string Currency { get; set; }
        public int TotalBusinessDays { get; set; }

    }
}
