using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API;
using Microsoft.AspNetCore.Mvc;
using Snappet.Core.Queries.ClassWorkStatistic;

namespace Snappet.API.Controllers
{
    [Route("api/v1/statistic")]
    [ApiController]
    public class DashboardStatisticController : ControllerBase
    {
        private readonly IGetClassWorkStatisticQuery _getClassWorkStatisticQuery;

        public DashboardStatisticController(IGetClassWorkStatisticQuery getClassWorkStatisticQuery)
        {
            _getClassWorkStatisticQuery = getClassWorkStatisticQuery;
        }

        [HttpGet("class-work")]
        public async Task<IActionResult> GetClassWorkStatistic()
        {
            try
            {
                var startDateTime = new DateTimeOffset(2015, 3, 24, 0, 0, 0, TimeSpan.Zero);
                var endDateTime = startDateTime.AddDays(1);

                var statisticQueryArgs = new GetClassWorkStatisticCommandArgs
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
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}
