using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using PenaltyCalculation.Business.Abstract;
using PenaltyCalculation.Entity.Dtos;

namespace PenaltyCalculation.WebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICountryService _countryService;
        private readonly ILibraryService _libraryService;

        public HomeController(ICountryService countryService, ILibraryService libraryService)
        {
            _countryService = countryService;
            _libraryService = libraryService;
        }

        public async Task<IActionResult> CalculatePenalty()
        {
            var countries = await _countryService.GetListForDropDown();
            if (countries.Success)
            {
                return View(new PenaltyForCalculateDto { CountryList = countries.Data });
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CalculatePenalty(PenaltyForCalculateDto penaltyForCalculateDto)
        {
            var result = await _libraryService.CalculatePenalty(penaltyForCalculateDto);
            if (result.Success)
            {
                return Json(new { data = result.Data, success = true });
            }
            return Json(new { success = false, message = result.Message });
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
