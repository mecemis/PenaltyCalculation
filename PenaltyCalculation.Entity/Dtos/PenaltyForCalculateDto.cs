using Microsoft.AspNetCore.Mvc.Rendering;
using PenaltyCalculation.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PenaltyCalculation.Entity.Dtos
{
    public class PenaltyForCalculateDto : IDto
    {
        public int CountryId { get; set; }
        public IEnumerable<SelectListItem> CountryList { get; set; }
        public DateTime ReturnDate { get; set; }
        public DateTime CheckOutDate { get; set; }
    }
}
