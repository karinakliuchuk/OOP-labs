using labaoop3.Data;
using labaoop3.Entities;
using labaoop3.Repository.Base;
using labaoop3.Entities;
using System.Collections.Generic;
using System.Linq;

namespace labaoop3.Repository.Impl
{
    public class DuelHistoryRepository : IDuelHistoryRepository
    {
        private readonly HogwartsDbContext _db;

        public DuelHistoryRepository(HogwartsDbContext db)
        {
            _db = db;
        }

        public DuelHistory Add(DuelHistory entity)
        {
            entity.Id = _db.DuelHistories.Any() ? _db.DuelHistories.Max(d => d.Id) + 1 : 1;
            entity.CreatedAt = System.DateTime.UtcNow;
            _db.DuelHistories.Add(entity);
            return entity;
        }

        public void Delete(int id) => _db.DuelHistories.RemoveAll(d => d.Id == id);

        public IEnumerable<DuelHistory> GetAll() => _db.DuelHistories.AsReadOnly();

        public DuelHistory? GetById(int id) => _db.DuelHistories.FirstOrDefault(d => d.Id == id);

        public void Update(DuelHistory entity)
        {
            var existing = GetById(entity.Id);
            if (existing == null) return;

            existing.TurnLog = entity.TurnLog;
            existing.RatingStake = entity.RatingStake;
        }
    }
}
