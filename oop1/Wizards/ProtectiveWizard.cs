namespace OOP2.Wizards
{
    // Оборонний чарівник, половина шкоди та спеціальне закляття
    public class DefensiveWizard : BaseWizard
    {
        public DefensiveWizard(string name, string house)
            : base(name, house)
        {
        }

        // Приймає половину шкоди
        public override void TakeDamage(int damage)
        {
            int reducedDamage = damage / 2;
            base.TakeDamage(reducedDamage);
        }

        // Завжди кастує захисне закляття
        public override Spell CastRandomSpell()
        {
            return new Spell("Протеґо+", 0, SpellEffect.Disarming);
        }
    }
}
