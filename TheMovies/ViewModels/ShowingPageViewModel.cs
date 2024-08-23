using System.Collections.ObjectModel;
using TheMovies.Models;
using TheMovies.MVVM;
using TheMovies.Persistence;

namespace TheMovies.ViewModels;

public class ShowingPageViewModel : ViewModelBase
{
    private ShowingRepo showingRepo;
    private MovieRepo movieRepo;
    private CinemaRepo cinemaRepo;

    private ObservableCollection<MovieViewModel> movieVMs = [];

    //Commands.
    //public RelayCommand NameOfCommand => new RelayCommand(execute => { }, canExecute => { return true; });
    


    private Movie movie;

    public Movie Movie
    {
        get { return movie; }
        set
        {
            movie = value;
            OnPropertyChanged();
        }
    }

    private int showingDuration;

    public int ShowingDuration
    {
        get { return showingDuration; }
        set
        {
            showingDuration = value;
            OnPropertyChanged();
        }
    }

    private DateTime showingDate;

    public DateTime ShowingDate
    {
        get { return showingDate; }
        set
        {
            showingDate = value;
            OnPropertyChanged();
        }
    }


    private Movie selectedItem;

    public Movie SelectedItem
    {
        get { return selectedItem; }
        set
        {
            selectedItem = value;
            OnPropertyChanged();
        }
    }

    private DateTime selectedDate;

    public DateTime SelectedDate
    {
        get { return selectedDate; }
        set
        {
            selectedDate = value;
            OnPropertyChanged();
        }
    }

    //public void AddAndSave()
    //{
    //    AddMovie();
    //    SaveToFile();
    //}

    //public void AddMovie()
    //{

    //    Movie movie = new Movie
    //    {
    //        Title = Title,
    //        Duration = Duration,
    //        Genre = Genre
    //    };


    //    if (String.IsNullOrEmpty(movie.Title) || movie.Duration <= 0 || String.IsNullOrEmpty(movie.Genre))
    //    {
    //        throw new ArgumentException("Title, duration, and genre cannot be empty");
    //    }
    //    else
    //    {
    //        movieRepo.Add(movie);
    //        MovieViewModel movieVM = new MovieViewModel(movie);
    //        MovieVMs.Add(movieVM);
    //    }

    //}

    //public void SaveToFile()
    //{
    //    movieRepo.SaveToFile();
    //}

    //public void LoadFromFile()
    //{
    //    movieRepo.LoadFromFile();
    //    MovieVMs.Clear();

    //    foreach (Movie movie in movieRepo.GetAll())
    //    {
    //        MovieVMs.Add(new MovieViewModel(movie));
    //    }
    //}

    //public bool CanAdd()
    //{
    //    if (String.IsNullOrWhiteSpace(Title) || Duration <= 0 || String.IsNullOrWhiteSpace(Genre))
    //    {
    //        return false;
    //    }
    //    else
    //    {
    //        return true;
    //    }

    //}


}
