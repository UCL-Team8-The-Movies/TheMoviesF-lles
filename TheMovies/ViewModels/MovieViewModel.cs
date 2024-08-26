using System.Diagnostics;
using TheMovies.Models;
using TheMovies.MVVM;

namespace TheMovies.ViewModels;

public class MovieViewModel : ViewModelBase
{
    public string Title { get; set; }
    public int Duration { get; set; }
    public string Genre { get; set; }
    public string Director { get; set; }
    public DateTime PremierDate { get; set; }


    public MovieViewModel(Movie movie)
    {
        this.Title = movie.Title;
        this.Duration = movie.Duration;
        this.Genre = movie.Genre;
        this.Director = movie.Director;
        this.PremierDate = movie.PremierDate;
    }

    public override string ToString()
    {
        return $"{Title},{Duration},{Genre},{Director},{PremierDate}";
    }
}




