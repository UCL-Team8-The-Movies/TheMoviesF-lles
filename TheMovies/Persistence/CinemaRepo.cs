using TheMovies.Models;

namespace TheMovies.Persistence;

public class CinemaRepo
{
    private List<Cinema> Cinemas = new List<Cinema>
    { 
        new Cinema() { Name = "Café biografen", City = "Hjerm", MaxCinemaHall = "2" },
        new Cinema() { Name = "Biografklubben Videbæk", City = "Videbæk", MaxCinemaHall = "2" },
        new Cinema() { Name = "Thorsminde Lokalbiograf", City = "Thorsminde", MaxCinemaHall = "2" },
        new Cinema() { Name = "Ræhr Bio", City = "Ræhr", MaxCinemaHall = "2" },
    };


    public IEnumerable<Cinema> GetAll()
    {
        return Cinemas;
    }


}
