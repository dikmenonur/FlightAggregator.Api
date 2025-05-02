
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using FlightAggregator.Api.Hubs;

namespace FlightAggregator.Api.Services
{
    public class MockB2BProvider : IFlightProviderService
    {
        private readonly IHubContext<SearchProgressHub> _hubContext;

        public MockB2BProvider(IHubContext<SearchProgressHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task<string> SearchFlightsAsync(string from, string to)
        {
            await Task.Delay(1000);
            var result = $"B2B: Flight from {from} to {to}";
            await _hubContext.Clients.All.SendAsync("NewFlightResult", result);
            return result;
        }
    }
}
