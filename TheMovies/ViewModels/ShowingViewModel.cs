using TheMovies.Models;
using TheMovies.MVVM;

namespace TheMovies.ViewModels;

public class ShowingViewModel : ViewModelBase
{
    public Cinema Cinema { get; set; }
    public Movie Movie { get; set; }
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
        return $"{Cinema.Name},{Cinema.City},{Cinema.MaxCinemaHall},{Movie.Title},{Movie.Genre},{Movie.Director},{ShowingDuration},{ShowingDate}";
    }

}
