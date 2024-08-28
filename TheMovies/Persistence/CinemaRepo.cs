using TheMovies.Models;

namespace TheMovies.Persistence;

public class CinemaRepo : IRepo<Cinema>
{
    private List<Cinema> Cinemas = new List<Cinema>
    { 
        new Cinema() { Name = "Cafe biografen", City = "Hjerm", MaxCinemaHall = 1, CinemaHalls = {"Sal 1"} },
        new Cinema() { Name = "Biografklubben Videbaek", City = "Videbaek", MaxCinemaHall = 2, CinemaHalls = {"Sal 1","Sal 2" } },
        new Cinema() { Name = "Thorsminde Lokalbiograf", City = "Thorsminde", MaxCinemaHall = 3, CinemaHalls = {"Sal 1","Sal 2", "Sal 3" } },
        new Cinema() { Name = "Raehr Bio", City = "Raehr", MaxCinemaHall = 1, CinemaHalls = {"Sal 1"}},
    };

    
    public IEnumerable<Cinema> GetAll()
    {
        return Cinemas;
    }


    public void Add(Cinema entity) { }

    public void LoadFromFile() { }


    public void SaveToFile() { }

    public void RemoveAll() { }
}
