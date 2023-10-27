namespace Messanger.Interfaces;

public interface IRepository<TModel, TView>
{
    public Task<int> CreateAsync(TView entity);
    public Task<int> UpdateAsync(int id, TView entity);
    public Task<int> DeleteAsync(int id);
    public Task<int> DeepDeletedAsync(int id);
    public Task<TModel> GetAsync(string email);
    public Task<List<TModel>> GetAllAsync();
}
