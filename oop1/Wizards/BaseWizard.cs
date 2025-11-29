using OOP2.Duels;
using System;
using System.Collections.Generic;

namespace OOP2.Wizards
{
    // Базовий клас чарівника
    public abstract class BaseWizard
    {
        public string Name { get; set; }
        public string House { get; set; }
        public int Health { get; set; }
        public List<Spell> KnownSpells { get; private set; }

        private List<DuelResult> duelHistory;

        public BaseWizard(string name, string house)
        {
            Name = name;
            House = house;
            Health = 100;
            KnownSpells = new List<Spell>();
            duelHistory = new List<DuelResult>();
        }

        // Навчитися закляттю
        public void LearnSpell(Spell spell)
        {
            KnownSpells.Add(spell);
        }

        // Каст випадкового закляття
        public virtual Spell CastRandomSpell()
        {
            if (KnownSpells.Count == 0)
            {
                return new Spell("Силовий імпульс", 10, SpellEffect.Disarming);
            }

            Random random = new Random();
            int index = random.Next(KnownSpells.Count);
            return KnownSpells[index];
        }

        // Отримати шкоду
        public virtual void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0) Health = 0;
        }

        // Додати дуель до історії
        public void AddDuelToHistory(DuelResult duelRecord)
        {
            duelHistory.Add(duelRecord);
        }

        // Вивід історії дуелей
        public void GetDuelHistory()
        {
            Console.WriteLine($"Історія дуелей чарівника {Name} ({House}):");
            Console.WriteLine($"Всього дуелей: {duelHistory.Count}");

            int wins = 0;
            int losses = 0;

            foreach (var duel in duelHistory)
            {
                if (duel.Winner.Name == Name)
                {
                    wins++;
                    Console.WriteLine($"Перемога #{duel.DuelId} проти {duel.Loser.Name}");
                }
                else
                {
                    losses++;
                    Console.WriteLine($"Поразка #{duel.DuelId} від {duel.Winner.Name}");
                }
            }

            Console.WriteLine($"Статистика: {wins} перемог, {losses} поразок");
            Console.WriteLine();
        }
    }
}
