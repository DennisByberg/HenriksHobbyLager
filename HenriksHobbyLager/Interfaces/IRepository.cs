namespace HenriksHobbyLager.Interfaces
{
    // Metoderna är asynkrona för att stödja långsamma operationer som databasanrop.
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<T>> SearchAsync(Func<T, bool> predicate);
    }
}