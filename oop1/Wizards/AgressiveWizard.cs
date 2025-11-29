namespace OOP2.Wizards
{
    // Агресивний чарівник, завдає +5 шкоди кожним закляттям
    public class AggressiveWizard : BaseWizard
    {
        public AggressiveWizard(string name, string house)
            : base(name, house)
        {
        }

        public override Spell CastRandomSpell()
        {
            // Отримуємо базове закляття та підвищуємо шкоду
            Spell baseSpell = base.CastRandomSpell();
            Spell enhancedSpell = new Spell(
                baseSpell.Name,
                baseSpell.Damage + 5,
                baseSpell.Effect
            );
            return enhancedSpell;
        }
    }
}
