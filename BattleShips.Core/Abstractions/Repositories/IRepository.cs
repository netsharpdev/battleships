namespace BattleShips.Core.Abstractions.Repositories
{
    public interface IRepository<T>
    {
        T Entity { get; }
        void Save(T entity);
    }
}
