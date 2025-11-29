using OOP2.Duels;

namespace OOP2.Duels
{
    // Фабрика для створення різних типів дуелей
    public class DuelFactory
    {
        // Створює стандартну дуель
        public BaseDuel CreateStandard()
        {
            return new StandardDuel();
        }

        // Створює смертельну дуель
        public BaseDuel CreateDeadly()
        {
            return new MortalDuel();
        }

        // Створює тренувальну дуель
        public BaseDuel CreateTraining()
        {
            return new TrainingDuel();
        }
    }
}
