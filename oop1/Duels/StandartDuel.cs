namespace OOP2.Duels
{
    // Стандартна дуель
    public class StandardDuel : BaseDuel
    {
        // Повертає рейтинг ставки для стандартної дуелі
        public override int GetRatingStake()
        {
            return 10; // фіксоване значення
        }
    }
}
