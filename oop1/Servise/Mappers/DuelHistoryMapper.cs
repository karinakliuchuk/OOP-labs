using labaoop3.Entities;
using labaoop3.Entities;
using labaoop3.Service.Views;
using labaoop3.Service.Views;
using labaoop3.Entities;

namespace labaoop3.Service.Mappers
{
    public static class DuelHistoryMapper
    {
        public static DuelHistoryDTO ToDto(DuelHistory e, string winnerName, string loserName) =>
            new DuelHistoryDTO
            {
                Id = e.Id,
                TurnLog = e.TurnLog,
                WinnerId = e.WinnerId,
                LoserId = e.LoserId,
                WinnerName = winnerName,
                LoserName = loserName,
                RatingStake = e.RatingStake,
                CreatedAt = e.CreatedAt
            };
    }
}
