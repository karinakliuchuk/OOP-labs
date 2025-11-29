using System.Collections.Generic;

public class DuelResult
{
    public int DuelId { get; set; }
    public List<Wizard> Contestants { get; set; }
    public Wizard Winner { get; set; }
    public Wizard Loser { get; set; }
    public List<string> TurnLog { get; set; }

    public DuelResult(int duelId, List<Wizard> contestants, Wizard winner, Wizard loser, List<string> turnLog)
    {
        // Присвоєння через ініціалізацію властивостей
        DuelId = duelId;
        Contestants = new List<Wizard>(contestants); 
        Winner = winner;
        Loser = loser;
        TurnLog = new List<string>(turnLog); 
    }
}
