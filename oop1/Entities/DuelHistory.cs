namespace labaoop3.Entities
{
    public class DuelHistory
    {
        public int Id { get; set; }
        public int WinnerId { get; set; }
        public int LoserId { get; set; }
        public string TurnLog { get; set; } = "";
        public int RatingStake { get; set; } = 0;
        public DateTime CreatedAt { get; set; }
    }
}
