using System;
using System.Collections.Generic;

public class Wizard
{
    public string Name { get; set; }
    public string House { get; set; }
    public int Health { get; set; }
    public List<Spell> KnownSpells { get; private set; }
    private List<DuelResult> duelHistory;

    public Wizard(string name, string house)
    {
        Name = name;
        House = house;
        Health = 100;
        KnownSpells = new List<Spell>();
        duelHistory = new List<DuelResult>();
    }

    public void LearnSpell(Spell spell)
    {
        KnownSpells.Add(spell);
    }

    public Spell CastRandomSpell()
    {
        if (KnownSpells.Count == 0)
        {
            return new Spell("Силовий імпульс", 10, SpellEffect.Disarming);
        }

        Random rand = new Random();
        return KnownSpells[rand.Next(KnownSpells.Count)];
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        if (Health < 0) Health = 0;
    }

    public void AddDuelToHistory(DuelResult duelRecord)
    {
        duelHistory.Add(duelRecord);
    }

    public void GetDuelHistory()
    {
        Console.WriteLine($"Історія дуелей чарівника {Name.ToUpper()} ({House}):");
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

        if (duelHistory.Count > 0)
        {
            Console.WriteLine($"Статистика: {wins} перемог, {losses} поразок");
        }
        else
        {
            Console.WriteLine("Ще не брав участі в дуелях");
        }
        Console.WriteLine();
    }
}