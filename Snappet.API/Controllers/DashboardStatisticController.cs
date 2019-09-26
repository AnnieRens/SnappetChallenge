using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Snappet.Core.Queries.ClassWorkStatistic;

namespace Snappet.API.Controllers
{
    [Route("api/v1/statistic")]
    [ApiController]
    public class DashboardStatisticController : ControllerBase
    {
        private readonly IGetClassWorkStatisticQuery _getClassWorkStatisticQuery;
        private readonly ILogger _logger;

        public DashboardStatisticController(IGetClassWorkStatisticQuery getClassWorkStatisticQuery,
            ILogger logger)
        {
            _getClassWorkStatisticQuery = getClassWorkStatisticQuery;
            _logger = logger;
        }

        [HttpGet("class-work")]
        public async Task<IActionResult> GetClassWorkStatistic()
        {
            try
            {
                var startDateTime = new DateTimeOffset(2015, 3, 24, 0, 0, 0, TimeSpan.Zero);
                var endDateTime = startDateTime.AddDays(1);

                var statisticQueryArgs = new GetClassWorkStatisticQueryArgs
                {
                    StartDateTime = startDateTime,
                    EndDateTime = endDateTime
                };

                var statisticModels = await _getClassWorkStatisticQuery.Ask(statisticQueryArgs);
                var response = ApiResponse<List<PupilWorkStatisticModel>>.Success(statisticModels);

                return Ok(response);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);

                return StatusCode(StatusCodes.Status500InternalServerError, ApiResponse.Error(e.Message));
            }
        }
    }
}
