using TheMovies.Models;
using TheMovies.MVVM;

namespace TheMovies.ViewModels;

public class ShowingViewModel : ViewModelBase
{
    public Cinema Cinema { get; set; }
    public Movie Movie { get; set; }

    // Tilføjet en sal til en showing da det vælges i ShowingPageWindow når en showing laves
    public string CinemaHall { get; set; }

    public int ShowingDuration { get; set; }
    public DateTime ShowingDate { get; set; }


    public ShowingViewModel(Showing showing)
    {
        this.Cinema = showing.Cinema;
        this.Movie = showing.Movie;
        this.ShowingDuration = showing.ShowingDuration;
        this.ShowingDate = showing.ShowingDate;
    }

    public override string ToString()
    {
        // fjernet MaxCinemaHall da den ikke behøver vises i en showing, det hører til cinema
        return $"{Cinema.Name},{Cinema.City},{CinemaHall},{Movie.Title},{Movie.Genre},{Movie.Director},{ShowingDuration},{ShowingDate}";
    }

}
