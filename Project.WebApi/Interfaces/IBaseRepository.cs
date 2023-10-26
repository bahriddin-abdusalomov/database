namespace Project.WebApi.Interfaces;

public interface IBaseRepository<T> where T : class
{
    public Task<int> CreateAsync(T entity);
    public Task<int> UpdateAsync(int id, T entity);
    public Task<int> DeleteAsync(int id);
    public Task<int> DeepDeletedAsync(int id);
    public Task<T> GetAsync(int id);
    public Task<List<T>> GetAllAsync();
}
