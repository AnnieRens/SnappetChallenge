using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Snappet.Core.AppService;

namespace Snappet.API.Controllers
{
    [Route("api/v1/class-progress")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ClassProgressStatisticController : ControllerBase
    {
        private readonly IClassWorkStatisticService _classWorkStatisticService;
        //private readonly ILogger _logger;

        public ClassProgressStatisticController(IClassWorkStatisticService classWorkStatisticService)
        {
            _classWorkStatisticService = classWorkStatisticService;
            //_logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetClassWorkStatistic(DateTime startDate, DateTime endDate)
        {
            var result = _classWorkStatisticService.GetClassCommonProgress(startDate, endDate);
            var response = ApiResponse<List<TimeSeriesPair<double>>>.Success(result);

            return Ok(response);
        }
    }
}
