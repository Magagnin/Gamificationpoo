namespace Gamification.Domain.Awards.Policies;

public class BonusPolicy
{
    public (int xp, string reason) CalcularXp(
        DateTimeOffset now,
        DateTimeOffset bonusStart,
        DateTimeOffset fullWeightEnd,
        DateTimeOffset finalDate,
        int baseXp)
    {
        if (now <= fullWeightEnd)
            return (baseXp, "janela integral");
        else if (now <= finalDate)
            return ((int)(baseXp * 0.5), "janela reduzida");
        else
            return (0, "fora da janela");
    }
}
