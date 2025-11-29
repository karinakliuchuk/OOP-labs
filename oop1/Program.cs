using System;
using System.Text;
using System.Linq;
using labaoop3;
using labaoop3.Data;
using labaoop3.Repository.Impl;
using labaoop3.Service.Base;
using labaoop3.Service.Impl;

namespace labaoop3
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var db = new HogwartsDbContext();

            var wizardRepo = new WizardRepository(db);
            var spellRepo = new SpellRepository(db);
            var duelRepo = new DuelHistoryRepository(db);

            IWizardService wizardService = new WizardService(wizardRepo, spellRepo);
            ISpellService spellService = new SpellService(spellRepo);
            IDuelService duelService = new DuelService(wizardRepo, spellRepo, duelRepo);

            Console.WriteLine("Wizards in DB:");
            foreach (var w in wizardService.GetAll())
                Console.WriteLine($" {w.Id}: {w.Name} ({w.House})");

            var wizardList = wizardService.GetAll().ToList();

            if (wizardList.Count < 2)
            {
                Console.WriteLine("\nНедостатньо чарівників для дуелі.");
                return;
            }

            var w1 = wizardList[0];
            var w2 = wizardList[1];

            Console.WriteLine($"\nПроведення Ranked дуелі: {w1.Name} vs {w2.Name}");
            var duelResultDto = duelService.HostDuel(w1.Id, w2.Id, DuelType.Ranked);

            Console.WriteLine("\n=== Лог дуелі ===");
            Console.WriteLine(duelResultDto.TurnLog);
            Console.WriteLine($"Переможець: {duelResultDto.WinnerName}, Лузер: {duelResultDto.LoserName}, Рейтинг на кону: {duelResultDto.RatingStake}");

            Console.WriteLine("\nAll Duel Histories in DB:");
            foreach (var d in duelRepo.GetAll())
                Console.WriteLine($" {d.Id}: WinnerId={d.WinnerId}, LoserId={d.LoserId}");
        }
    }
}
