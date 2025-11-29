using System;
using System.Collections.Generic;

public class DuelingClub
{
    private static int duelCounter = 1;

    public DuelResult HostDuel(Wizard wizard1, Wizard wizard2)
    {
        // Відновлюємо здоров'я
        wizard1.Health = 100;
        wizard2.Health = 100;

        List<string> log = new List<string>();
        int duelId = duelCounter++;

        log.Add($"Початок дуелі #{duelId}: {wizard1.Name} vs {wizard2.Name}");

        if (wizard1.KnownSpells.Count == 0)
            log.Add($"{wizard1.Name} не знає заклять і застосовує Силовий імпульс");

        if (wizard2.KnownSpells.Count == 0)
            log.Add($"{wizard2.Name} не знає заклять і застосовує Силовий імпульс");

        int round = 1;
        while (wizard1.Health > 0 && wizard2.Health > 0)
        {
            log.Add($"~~~ Хід {round} ~~~");

            // Хід першого чарівника
            Spell currentSpell = wizard1.CastRandomSpell();
            int prevHealth = wizard2.Health;
            wizard2.TakeDamage(currentSpell.Damage);

            log.Add(currentSpell.Name == "Силовий імпульс"
                ? $"{wizard1.Name} використовує {currentSpell.Name} (базове закляття) і завдає {currentSpell.Damage} шкоди. {wizard2.Name}: {prevHealth} -> {wizard2.Health}"
                : $"{wizard1.Name} кастує {currentSpell.Name}, шкода: {currentSpell.Damage}. {wizard2.Name}: {prevHealth} -> {wizard2.Health}");

            if (wizard2.Health <= 0) break;

            // Хід другого чарівника
            currentSpell = wizard2.CastRandomSpell();
            prevHealth = wizard1.Health;
            wizard1.TakeDamage(currentSpell.Damage);

            log.Add(currentSpell.Name == "Силовий імпульс"
                ? $"{wizard2.Name} використовує {currentSpell.Name} (базове закляття) і завдає {currentSpell.Damage} шкоди. {wizard1.Name}: {prevHealth} -> {wizard1.Health}"
                : $"{wizard2.Name} кастує {currentSpell.Name}, шкода: {currentSpell.Damage}. {wizard1.Name}: {prevHealth} -> {wizard1.Health}");

            round++;
        }

        // Визначення переможця
        Wizard winner = wizard1.Health > 0 ? wizard1 : wizard2;
        Wizard loser = wizard1.Health > 0 ? wizard2 : wizard1;

        log.Add($"Переможець: {winner.Name} (здоров'я: {winner.Health})");

        DuelResult result = new DuelResult(
            duelId,
            new List<Wizard> { wizard1, wizard2 },
            winner,
            loser,
            log
        );

        // Додаємо дуель в історію
        wizard1.AddDuelToHistory(result);
        wizard2.AddDuelToHistory(result);

        // Вивід логу
        foreach (var entry in log)
            Console.WriteLine(entry);
        Console.WriteLine();

        return result;
    }
}
