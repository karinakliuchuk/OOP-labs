namespace labaoop3.Service.Views
{
    public class DuelHistoryDTO
    {
        public int Id { get; set; }
        public string TurnLog { get; set; } = "";
        public int WinnerId { get; set; }
        public string WinnerName { get; set; } = "";
        public int LoserId { get; set; }
        public string LoserName { get; set; } = "";
        public int RatingStake { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
