using labaoop3.Entities;
using System;
using System.Collections.Generic;

namespace labaoop3.Data
{
    public class HogwartsDbContext
    {
        public List<WizardEntity> Wizards { get; set; }
        public List<SpellEntity> Spells { get; set; }
        public List<WizardSpell> WizardSpells { get; set; }
        public List<DuelHistory> DuelHistories { get; set; }

        public HogwartsDbContext()
        {
            Wizards = new List<WizardEntity>();
            Spells = new List<SpellEntity>();
            WizardSpells = new List<WizardSpell>();
            DuelHistories = new List<DuelHistory>();

            InitializeData();
        }

        // Метод для заповнення базових даних
        private void InitializeData()
        {
            // Чарівники
            Wizards.AddRange(new[]
            {
                new WizardEntity { Id = 1, Name = "Альбус Дамблдор", House = "Гріффіндор" },
                new WizardEntity { Id = 2, Name = "Сіріус Блек", House = "Гріффіндор" },
                new WizardEntity { Id = 3, Name = "Драко Мелфой", House = "Слизерин" },
                new WizardEntity { Id = 4, Name = "Лорд Волдеморт", House = "Рицарі Темряви" }
            });

            // Закляття
            Spells.AddRange(new[]
            {
                new SpellEntity { Id = 1, Name = "Експеліармус", Damage = 20, Effect = "Disarming" },
                new SpellEntity { Id = 2, Name = "Ступефай", Damage = 15, Effect = "Stunning" },
                new SpellEntity { Id = 3, Name = "Сектумсемпра", Damage = 30, Effect = "Damage" },
                new SpellEntity { Id = 4, Name = "Протеґо", Damage = 0, Effect = "Shield" }
            });

            // Відношення чарівник ↔ закляття
            WizardSpells.AddRange(new[]
            {
                new WizardSpell { Id = 1, WizardId = 1, SpellId = 1 },
                new WizardSpell { Id = 2, WizardId = 1, SpellId = 4 },
                new WizardSpell { Id = 3, WizardId = 2, SpellId = 1 },
                new WizardSpell { Id = 4, WizardId = 3, SpellId = 2 },
                new WizardSpell { Id = 5, WizardId = 3, SpellId = 4 },
                new WizardSpell { Id = 6, WizardId = 4, SpellId = 3 },
                new WizardSpell { Id = 7, WizardId = 4, SpellId = 1 }
            });
        }
    }
}
