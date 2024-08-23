namespace TheMovies.Models;

public class Movie
{

    public string Title { get; set; }
    public int Duration { get; set; }
    public string Genre { get; set; }

    public string Director { get; set; }
    public DateTime PremierDate { get; set; }

}
