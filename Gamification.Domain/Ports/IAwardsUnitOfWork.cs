namespace Gamification.Domain.Ports;

public interface IAwardsUnitOfWork
{
    void Begin();
    void Commit();
    void Rollback();
}
