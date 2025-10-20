using Xunit;
using Gamification.Domain.Awards.Policies;
using System;

public class BonusPolicyTests
{
    [Fact]
    public void ConcederBadge_ate_bonusFullWeightEndDate_concede_bonus_integral()
    {
        var policy = new BonusPolicy();
        var now = DateTimeOffset.UtcNow;
        var result = policy.CalcularXp(now, now.AddDays(-1), now.AddDays(1), now.AddDays(2), 100);

        Assert.Equal(100, result.xp);
        Assert.Equal("janela integral", result.reason);
    }
}
