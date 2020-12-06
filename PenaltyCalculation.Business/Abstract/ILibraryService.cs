using Microsoft.AspNetCore.Mvc.Rendering;
using PenaltyCalculation.Core.Utilities.Results;
using PenaltyCalculation.Entity.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PenaltyCalculation.Business.Abstract
{
    public interface ILibraryService
    {
        Task<IDataResult<PenaltyForDetailDto>> CalculatePenalty(PenaltyForCalculateDto penaltyForCalculateDto);
    }
}
