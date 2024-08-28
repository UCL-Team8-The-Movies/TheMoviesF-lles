namespace TheMovies.Persistence;

public interface IRepo<T>
{
    public void Add(T entity);
    public IEnumerable<T> GetAll();

    public void SaveToFile();

    public void LoadFromFile();

    public void RemoveAll();
}
