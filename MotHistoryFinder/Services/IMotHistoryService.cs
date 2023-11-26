using MotHistoryFinder.Models;

namespace MotHistoryFinder.Services
{
    public interface IMotHistoryService
    {
        Task<List<MotHistoryDto>> GetMotHistory(string queryStringValue);
    }
}
