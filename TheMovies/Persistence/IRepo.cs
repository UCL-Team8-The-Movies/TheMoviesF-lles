namespace TheMovies.Persistence;

public interface IRepo<T>
{
    public void Add(T entity);
    public IEnumerable<T> GetAll(); 
}
