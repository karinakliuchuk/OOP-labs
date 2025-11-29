using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        Console.WriteLine("=== Магічний клуб дуелянтів ===\n");

        // Ініціалізація заклинань
        var spellStun1 = new Spell("Ступефай", 15, SpellEffect.Stunning);
        var spellStun2 = new Spell("Петрифікус Тоталус", 20, SpellEffect.Stunning);
        var spellDisarm = new Spell("Експеліармус", 25, SpellEffect.Disarming);
        var spellCut = new Spell("Сектумсемпра", 30, SpellEffect.Damage);
        var spellShield = new Spell("Протеґо", 0, SpellEffect.Disarming);
        var spellFire = new Spell("Інсендіо", 18, SpellEffect.Damage);
        var spellLevitate = new Spell("Левікорпус", 22, SpellEffect.Stunning);

        // Створення персонажів
        var wizDumbledore = new Wizard("Альбус Дамблдор", "Гріффіндор");
        var wizNarcissa = new Wizard("Нарциса Мелфой", "Слизерин");
        var wizSirius = new Wizard("Сіріус Блек", "Гріффіндор");

        // Навчання чарівників
        wizDumbledore.LearnSpell(spellDisarm);
        wizDumbledore.LearnSpell(spellShield);
        wizDumbledore.LearnSpell(spellStun2);
        wizDumbledore.LearnSpell(spellFire);

        wizNarcissa.LearnSpell(spellCut);
        wizNarcissa.LearnSpell(spellStun1);
        wizNarcissa.LearnSpell(spellLevitate);

        wizSirius.LearnSpell(spellStun1);
        wizSirius.LearnSpell(spellDisarm);
        wizSirius.LearnSpell(spellShield);
        wizSirius.LearnSpell(spellFire);

        // Створення клубу дуелей
        var duelClub = new DuelingClub();

        // Проведення боїв
        Console.WriteLine("=== ДУЕЛЬ 1: Дамблдор проти Нарциси ===");
        duelClub.HostDuel(wizDumbledore, wizNarcissa);

        Console.WriteLine("=== ДУЕЛЬ 2: Сіріус проти Нарциси ===");
        duelClub.HostDuel(wizSirius, wizNarcissa);

        Console.WriteLine("=== ДУЕЛЬ 3: Дамблдор проти Сіріуса ===");
        duelClub.HostDuel(wizDumbledore, wizSirius);

        // Історія дуелей
        Console.WriteLine("\n=== ЗВІТ ПРО ДУЕЛІ ===");
        wizDumbledore.GetDuelHistory();
        wizNarcissa.GetDuelHistory();
        wizSirius.GetDuelHistory();

        Console.WriteLine("\nНатисніть будь-яку клавішу, щоб завершити...");
        Console.ReadKey();
    }
}
