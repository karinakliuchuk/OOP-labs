using System;
using System.Collections.Generic;
using OOP2.Wizards;

namespace OOP2.Duels
{
    public class DuelingClub
    {
        private static int duelCounter = 1;

        public DuelResult HostDuel(BaseWizard wizard1, BaseWizard wizard2, BaseDuel duel)
        {
            // Відновлюємо здоров'я перед дуеллю
            wizard1.Health = 100;
            wizard2.Health = 100;

            List<string> turnLog = new List<string>();
            int duelId = duelCounter++;

            turnLog.Add($"Старт дуелі #{duelId}: {wizard1.Name} vs {wizard2.Name}");

            int round = 1;
            while (wizard1.Health > 0 && wizard2.Health > 0)
            {
                turnLog.Add($"--- Раунд {round} ---");

                // Хід першого чарівника
                var spell1 = wizard1.CastRandomSpell();
                int prevHealth = wizard2.Health;
                wizard2.TakeDamage(spell1.Damage);
                turnLog.Add($"{wizard1.Name} застосовує {spell1.Name} (шкода {spell1.Damage}). {wizard2.Name}: {prevHealth} -> {wizard2.Health}");

                if (wizard2.Health <= 0) break;

                // Хід другого чарівника
                var spell2 = wizard2.CastRandomSpell();
                prevHealth = wizard1.Health;
                wizard1.TakeDamage(spell2.Damage);
                turnLog.Add($"{wizard2.Name} застосовує {spell2.Name} (шкода {spell2.Damage}). {wizard1.Name}: {prevHealth} -> {wizard1.Health}");

                round++;
            }

            BaseWizard winner = wizard1.Health > 0 ? wizard1 : wizard2;
            BaseWizard loser = wizard1.Health > 0 ? wizard2 : wizard1;

            turnLog.Add($"\nПереможець: {winner.Name}");
            turnLog.Add($"На кону було: {duel.GetRatingStake()} балів рейтингу");

            var result = new DuelResult(
                duelId,
                new List<BaseWizard> { wizard1, wizard2 },
                winner,
                loser,
                turnLog
            );

            wizard1.AddDuelToHistory(result);
            wizard2.AddDuelToHistory(result);

            // Вивід логу дуелі
            foreach (var entry in turnLog)
                Console.WriteLine(entry);

            Console.WriteLine();
            return result;
        }
    }
}
