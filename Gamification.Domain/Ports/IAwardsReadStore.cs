namespace Gamification.Domain.Ports;

public interface IAwardsReadStore
{
    bool MissaoConcluida(Guid studentId, Guid missionId);
    bool JaPossuiBadge(Guid studentId, Guid missionId, string badgeSlug);
    (DateTimeOffset bonusStartDate, DateTimeOffset bonusFullWeightEndDate, DateTimeOffset bonusFinalDate) ObterBonusDates(Guid missionId);
}
