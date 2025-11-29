namespace OOP2.Duels
{
    // Тренувальна дуель
    public class TrainingDuel : BaseDuel
    {
        // Повертає рейтинг ставки для тренувальної дуелі
        public override int GetRatingStake()
        {
            return 0; // Без ризику
        }
    }
}
