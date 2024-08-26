namespace TheMovies.Models;

public class Cinema
{
    public string Name { get; set; }
    public string City { get; set; }



    // Ændret til int (Se ShowingRepo LoadFromFile())
    public int MaxCinemaHall { get; set; }

    // Added Liste af Halls Property (Se ShowingRepo LoadFromFile())
    public List<string> CinemaHalls { get; set; }

    // Nye Cinema objekter skal bruge en liste til CinemaHalls (Se CinemaRepo)
    public Cinema()
    {
        CinemaHalls = new List<string>();
    }
}
