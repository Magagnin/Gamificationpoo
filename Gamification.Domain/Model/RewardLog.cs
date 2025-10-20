namespace Gamification.Domain.Model;

public class RewardLog
{
    public Guid StudentId { get; init; }
    public Guid MissionId { get; init; }
    public string BadgeSlug { get; init; } = string.Empty;
    public int Xp { get; init; }
    public string Reason { get; init; } = string.Empty;
    public DateTimeOffset Date { get; init; } = DateTimeOffset.UtcNow;
}
