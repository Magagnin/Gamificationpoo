using Gamification.Domain.Model;
using Gamification.Domain.Ports;
using Gamification.Domain.Awards.Policies;

namespace Gamification.Domain.Awards;

public class AwardBadgeService
{
    private readonly IAwardsReadStore _readStore;
    private readonly IAwardsWriteStore _writeStore;

    public AwardBadgeService(IAwardsReadStore readStore, IAwardsWriteStore writeStore)
    {
        _readStore = readStore;
        _writeStore = writeStore;
    }

    public void ConcederBadge(Guid studentId, Guid missionId, string badgeSlug, DateTimeOffset now, Guid? requestId = null)
    {
        if (!_readStore.MissaoConcluida(studentId, missionId))
            throw new InvalidOperationException("Elegibilidade não satisfeita: missão não concluída.");

        if (_readStore.JaPossuiBadge(studentId, missionId, badgeSlug))
            throw new InvalidOperationException("Badge já concedida para esta missão.");

        var bonusInfo = _readStore.ObterBonusDates(missionId);
        var xpBase = 100;
        var policy = new BonusPolicy();
        var (xp, reason) = policy.CalcularXp(now, bonusInfo.bonusStartDate, bonusInfo.bonusFullWeightEndDate, bonusInfo.bonusFinalDate, xpBase);

        _writeStore.SalvarConcessaoAtomica(studentId, missionId, badgeSlug, xp, reason, requestId);
    }
}
