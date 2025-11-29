using labaoop3.Entities;
using labaoop3.Entities;
using labaoop3.Repository.Base;
using labaoop3.Repository.Base;
using labaoop3.Service.Base;
using labaoop3.Service.Base;
using labaoop3.Service.Mappers;
using labaoop3.Service.Mappers;
using labaoop3.Service.Views;
using labaoop3.Service.Views;
using labaoop3.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace labaoop3.Service.Impl
{
    public class DuelService : IDuelService
    {
        private readonly IWizardRepository _wizardRepo;
        private readonly ISpellRepository _spellRepo;
        private readonly IDuelHistoryRepository _duelRepo;
        private readonly Random _rand = new();

        public DuelService(IWizardRepository wr, ISpellRepository sr, IDuelHistoryRepository dr)
        {
            _wizardRepo = wr;
            _spellRepo = sr;
            _duelRepo = dr;
        }

        // Описи ставок для типу дуелі
        private int GetStake(DuelType t) => t switch
        {
            DuelType.Training => 0,
            DuelType.Ranked => 10,
            DuelType.Deadly => 50,
            _ => 0
        };

        public DuelHistoryDTO HostDuel(int wizard1Id, int wizard2Id, DuelType duelType)
        {
            var w1 = _wizardRepo.GetById(wizard1Id) ?? throw new ArgumentException("wizard1 not found");
            var w2 = _wizardRepo.GetById(wizard2Id) ?? throw new ArgumentException("wizard2 not found");
            var w1Spells = _wizardRepo.GetSpellsForWizard(w1.Id).ToList();
            var w2Spells = _wizardRepo.GetSpellsForWizard(w2.Id).ToList();

            int health1 = 100;
            int health2 = 100;

            var log = new StringBuilder();
            log.AppendLine($"Start duel: {w1.Name} vs {w2.Name} ({duelType})");

            int turn = 1;
            while (health1 > 0 && health2 > 0 && turn <= 100) // cap turns
            {
                log.AppendLine($"-- Turn {turn} --");

                // w1 attacks
                if (w1Spells.Count == 0) w1Spells = _spellRepo.GetAll().ToList();
                var s1 = w1Spells[_rand.Next(w1Spells.Count)];
                int dmg1 = s1.Damage;
                health2 -= dmg1;
                log.AppendLine($"{w1.Name} casts {s1.Name} ({dmg1}). {w2.Name}: {Math.Max(0, health2 + dmg1)} -> {Math.Max(0, health2)}");
                if (health2 <= 0) break;

                // w2 attacks
                if (w2Spells.Count == 0) w2Spells = _spellRepo.GetAll().ToList();
                var s2 = w2Spells[_rand.Next(w2Spells.Count)];
                int dmg2 = s2.Damage;
                health1 -= dmg2;
                log.AppendLine($"{w2.Name} casts {s2.Name} ({dmg2}). {w1.Name}: {Math.Max(0, health1 + dmg2)} -> {Math.Max(0, health1)}");

                turn++;
            }

            var winner = health1 > health2 ? w1 : w2;
            var loser = winner == w1 ? w2 : w1;
            log.AppendLine($"Winner: {winner.Name}");

            // Зберігаємо історію
            var duelEntity = new DuelHistory
            {
                WinnerId = winner.Id,
                LoserId = loser.Id,
                TurnLog = log.ToString(),
                RatingStake = GetStake(duelType)
            };

            var saved = _duelRepo.Add(duelEntity);

            // Повертаємо DTO (маппінг)
            return DuelHistoryMapper.ToDto(saved, winner.Name, loser.Name);
        }
    }
}
