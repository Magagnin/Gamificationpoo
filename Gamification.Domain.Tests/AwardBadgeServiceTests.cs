using Xunit;
using Gamification.Domain.Awards;
using Gamification.Domain.Ports;
using System;

public class AwardBadgeServiceTests
{
    [Fact]
    public void ConcederBadge_quando_missao_concluida_concede_uma_unica_vez()
    {
        var readStore = new FakeReadStore();
        var writeStore = new FakeWriteStore();
        var service = new AwardBadgeService(readStore, writeStore);

        service.ConcederBadge(Guid.NewGuid(), Guid.NewGuid(), "hero-badge", DateTimeOffset.UtcNow);

        Assert.True(writeStore.Gravou);
    }

    private class FakeReadStore : IAwardsReadStore
    {
        public bool MissaoConcluida(Guid s, Guid m) => true;
        public bool JaPossuiBadge(Guid s, Guid m, string b) => false;
        public (DateTimeOffset, DateTimeOffset, DateTimeOffset) ObterBonusDates(Guid m)
        {
            var now = DateTimeOffset.UtcNow;
            return (now.AddDays(-1), now.AddDays(1), now.AddDays(2));
        }
    }

    private class FakeWriteStore : IAwardsWriteStore
    {
        public bool Gravou { get; private set; }
        public void SalvarConcessaoAtomica(Guid s, Guid m, string b, int xp, string reason, Guid? r)
            => Gravou = true;
    }
}
