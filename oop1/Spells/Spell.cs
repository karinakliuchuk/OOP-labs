namespace OOP2
{
    // Тип ефекту закляття
    public enum SpellEffect
    {
        Disarming,   // Роззброєння
        Stunning,    // Приголомшення
        Damage       // Шкода
    }

    // Клас закляття
    public class Spell
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public SpellEffect Effect { get; set; }

        // Конструктор закляття
        public Spell(string name, int damage, SpellEffect effect)
        {
            Name = name;
            Damage = damage;
            Effect = effect;
        }
    }
}
