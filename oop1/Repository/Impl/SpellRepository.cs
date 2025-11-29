using labaoop3.Data;
using labaoop3.Entities;
using labaoop3.Repository.Base;
using System.Collections.Generic;
using System.Linq;

namespace labaoop3.Repository.Impl
{
    public class SpellRepository : ISpellRepository
    {
        private readonly HogwartsDbContext _db;

        public SpellRepository(HogwartsDbContext db)
        {
            _db = db;
        }

        public SpellEntity Add(SpellEntity entity)
        {
            entity.Id = _db.Spells.Any() ? _db.Spells.Max(s => s.Id) + 1 : 1;
            _db.Spells.Add(entity);
            return entity;
        }

        public void Delete(int id) => _db.Spells.RemoveAll(s => s.Id == id);

        public IEnumerable<SpellEntity> GetAll() => _db.Spells.AsReadOnly();

        public SpellEntity? GetById(int id) => _db.Spells.FirstOrDefault(s => s.Id == id);

        public void Update(SpellEntity entity)
        {
            var existing = GetById(entity.Id);
            if (existing == null) return;

            existing.Name = entity.Name;
            existing.Damage = entity.Damage;
            existing.Effect = entity.Effect;
        }
    }
}
