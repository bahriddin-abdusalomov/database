namespace Messanger.Interfaces;

public interface IRepository<TModel>
{
    public Task<int> CreateAsync(TModel model);
    public Task<int> UpdateAsync(Guid id, TModel model);
    public Task<int> DeleteAsync(Guid id);
    public Task<TModel> GetByIdAsync(string email);
    public Task<List<TModel>> GetAllAsync();

}
