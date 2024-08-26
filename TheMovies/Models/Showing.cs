namespace TheMovies.Models;

public class Showing
{
    public Movie Movie { get; set; }
    public Cinema Cinema { get; set; }
    
    // Tilføjet en sal til en showing da det vælges i ShowingPageWindow vinduet
    public string CinemaHall { get; set; }
    
    public int ShowingDuration { get; set; }
    public DateTime ShowingDate { get; set; }

}
