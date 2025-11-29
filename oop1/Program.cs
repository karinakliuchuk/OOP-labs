using System;
using System.Text;
using OOP2;
using OOP2.Wizards;
using OOP2.Duels;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        // Створюємо закляття
        Spell stupify = new Spell("Ступефай", 15, SpellEffect.Stunning);
        Spell petrificus = new Spell("Петрифікус", 20, SpellEffect.Stunning);
        Spell expelliarmus = new Spell("Експеліармус", 25, SpellEffect.Disarming);
        Spell incendio = new Spell("Інсендіо", 18, SpellEffect.Damage);

        // Створюємо чарівників
        BaseWizard voldemort = new AggressiveWizard("Лорд Волдеморт", "Слизерин");
        BaseWizard draco = new DefensiveWizard("Драко Мелфой", "Слизерин");
        BaseWizard harry = new RandomWizard("Гаррі Поттер", "Гріффіндор");

        // Навчання заклять
        voldemort.LearnSpell(expelliarmus);
        voldemort.LearnSpell(petrificus);

        draco.LearnSpell(stupify);
        draco.LearnSpell(incendio);

        harry.LearnSpell(stupify);
        harry.LearnSpell(expelliarmus);

        // Створюємо фабрику дуелей та клуб
        DuelFactory duelFactory = new DuelFactory();
        DuelingClub club = new DuelingClub();

        // Проведення дуелей
        Console.WriteLine("=== ПРОВЕДЕННЯ ДУЕЛЕЙ ===");
        club.HostDuel(voldemort, draco, duelFactory.CreateStandard());
        club.HostDuel(harry, draco, duelFactory.CreateDeadly());
        club.HostDuel(voldemort, harry, duelFactory.CreateTraining());

        // Вивід історії дуелей
        Console.WriteLine("\n=== ІСТОРІЯ ДУЕЛЕЙ ===");
        voldemort.GetDuelHistory();
        draco.GetDuelHistory();
        harry.GetDuelHistory();

        Console.WriteLine("Натисніть будь-яку клавішу для виходу...");
        Console.ReadKey();
    }
}
