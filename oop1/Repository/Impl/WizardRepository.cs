using labaoop3.Data;
using labaoop3.Entities;
using labaoop3.Repository.Base;
using System.Collections.Generic;
using System.Linq;

namespace labaoop3.Repository.Impl
{
    public class WizardRepository : IWizardRepository
    {
        private readonly HogwartsDbContext _db;

        public WizardRepository(HogwartsDbContext db)
        {
            _db = db;
        }

        public WizardEntity Add(WizardEntity entity)
        {
            entity.Id = _db.Wizards.Any() ? _db.Wizards.Max(w => w.Id) + 1 : 1;
            _db.Wizards.Add(entity);
            return entity;
        }

        public void Delete(int id) => _db.Wizards.RemoveAll(w => w.Id == id);

        public IEnumerable<WizardEntity> GetAll() => _db.Wizards.AsReadOnly();

        public WizardEntity? GetById(int id) => _db.Wizards.FirstOrDefault(w => w.Id == id);

        public void Update(WizardEntity entity)
        {
            var existing = GetById(entity.Id);
            if (existing == null) return;

            existing.Name = entity.Name;
            existing.House = entity.House;
        }

        public IEnumerable<SpellEntity> GetSpellsForWizard(int wizardId)
        {
            var spellIds = _db.WizardSpells
                              .Where(ws => ws.WizardId == wizardId)
                              .Select(ws => ws.SpellId);

            return _db.Spells.Where(s => spellIds.Contains(s.Id)).ToList();
        }
    }
}
