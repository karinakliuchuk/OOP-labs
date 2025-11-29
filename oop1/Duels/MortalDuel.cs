namespace OOP2.Duels
{
    // Клас смертельної дуелі, наслідує BaseDuel
    public class MortalDuel : BaseDuel
    {
        // Повертає рейтинг ставки для смертельної дуелі
        public override int GetRatingStake()
        {
            return 50; // Фіксоване значення
        }
    }
}
