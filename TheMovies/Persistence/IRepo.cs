namespace TheMovies.Persistence;

internal interface IRepo<T>
{
    public void Add(T entity);
    public IEnumerable<T> GetAll(); 
}
