namespace HenriksHobbyLager.Interfaces
{
    // Läsoperationer
    public interface IReadRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<IEnumerable<T>> SearchAsync(Func<T, bool> predicate);
    }

    // Skrivoperationer
    public interface IWriteRepository<T>
    {
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }

    // både läs- och skrivoperationer
    public interface IRepository<T> : IReadRepository<T>, IWriteRepository<T>;
}