namespace Gamification.Domain.Ports;

public interface IAwardsWriteStore
{
    void SalvarConcessaoAtomica(Guid studentId, Guid missionId, string badgeSlug, int xp, string reason, Guid? requestId);
}
