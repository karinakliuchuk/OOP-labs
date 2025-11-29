using System;

namespace OOP2.Wizards
{
    // Чарівник з випадковими закляттями та шансом на Армагеддон
    public class RandomWizard : BaseWizard
    {
        private Random randomGenerator = new Random();

        public RandomWizard(string name, string house)
            : base(name, house)
        {
        }

        public override Spell CastRandomSpell()
        {
            // 20% шанс використати Армагеддон
            int chance = randomGenerator.Next(100);
            if (chance < 20)
            {
                return new Spell("Армагеддон", 40, SpellEffect.Damage);
            }

            // Інакше випадкове закляття з відомих
            return base.CastRandomSpell();
        }
    }
}
