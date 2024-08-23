namespace TheMovies.Models;

public class Showing
{
    public Movie Movie { get; set; }
    public Cinema Cinema { get; set; }
    public int ShowingDuration { get; set; }
    public DateTime ShowingDate { get; set; }
}
