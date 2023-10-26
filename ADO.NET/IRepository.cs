namespace ADO.NET;

public interface IRepository<TModel> where TModel : class
{
    void GetByIdAsync(int id);
    void Insert(TModel model);
}
