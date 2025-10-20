namespace Gamification.Domain.Model;

public readonly record struct XpAmount(int Value)
{
    public static XpAmount Zero => new(0);
    public bool IsZero => Value == 0;
}
