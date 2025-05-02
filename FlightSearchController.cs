
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FlightAggregator.Api.Hubs;
using FlightAggregator.Api.Services;

namespace FlightAggregator.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightSearchController : ControllerBase
    {
        private readonly IHubContext<SearchProgressHub> _hubContext;

        public FlightSearchController(IHubContext<SearchProgressHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchFlights(string from, string to)
        {
            var providers = new List<IFlightProviderService> {
                new MockB2BProvider(_hubContext),
                new MockB2CProvider(_hubContext)
            };

            var tasks = providers.Select(p => p.SearchFlightsAsync(from, to)).ToList();
            var firstResponse = await Task.WhenAny(tasks);
            var result = await firstResponse;

            return Ok(result);
        }
    }
}
