
using System.Threading.Tasks;

namespace FlightAggregator.Api.Services
{
    public interface IFlightProviderService
    {
        Task<string> SearchFlightsAsync(string from, string to);
    }
}
