using labaoop3.Service.Views;

namespace labaoop3.Service.Base
{
    public enum DuelType
    {
        Training,
        Ranked,
        Deadly
    }

    public interface IDuelService
    {
        DuelHistoryDTO HostDuel(int wizard1Id, int wizard2Id, DuelType duelType);
    }
}
