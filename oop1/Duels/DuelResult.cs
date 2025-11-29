using System.Collections.Generic;
using OOP2.Wizards;

namespace OOP2.Duels
{
    // Клас для збереження результатів дуелі
    public class DuelResult
    {
        public int DuelId { get; set; }
        public List<BaseWizard> Contestants { get; set; }
        public BaseWizard Winner { get; set; }
        public BaseWizard Loser { get; set; }
        public List<string> TurnLog { get; set; }

        public DuelResult(int duelId, List<BaseWizard> contestants, BaseWizard winner, BaseWizard loser, List<string> turnLog)
        {
            DuelId = duelId;
            // Копіюємо списки для безпечності, щоб оригінальні не змінювались випадково
            Contestants = new List<BaseWizard>(contestants);
            Winner = winner;
            Loser = loser;
            TurnLog = new List<string>(turnLog);
        }
    }
}
