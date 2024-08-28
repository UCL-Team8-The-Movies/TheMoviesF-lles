using System.Collections.ObjectModel;
using TheMovies.Models;
using TheMovies.MVVM;
using TheMovies.Persistence;

namespace TheMovies.ViewModels;

public class MoviePageViewModel : ViewModelBase
{
    public IRepo<Movie> movieRepo;
    public ObservableCollection<MovieViewModel> MovieVMs { get; set; }

    //Commands.
    //public RelayCommand NameOfCommand => new RelayCommand(execute => { }, canExecute => { return true; });
    public RelayCommand LoadCommand => new RelayCommand(execute => LoadFromFile(), canExecute => { return true; });
    public RelayCommand AddAndSaveCommand => new RelayCommand(execute => AddAndSave(), canExecute => CanAdd());
    public RelayCommand BackToMainCommand => new RelayCommand(execute => BackToMain(), canExecute => { return true; });

    public MoviePageViewModel()
    {
        movieRepo = new MovieRepo();
        MovieVMs = [];
        LoadFromFile();
    }

    private string title;

    public string Title
    {
        get { return title; }
        set
        {
            title = value;
            OnPropertyChanged();
        }
    }

    private int duration;

    public int Duration
    {
        get { return duration; }
        set
        {
            duration = value;
            OnPropertyChanged();
        }
    }

    private string genre;

    public string Genre
    {
        get { return genre; }
        set
        {
            genre = value;
            OnPropertyChanged();
        }
    }

    private string director;

    public string Director
    {
        get { return director; }
        set 
        { 
            director = value; 
            OnPropertyChanged();
        }
    }


    private DateTime premierDate;

    public DateTime PremierDate
    {
        get { return premierDate; }
        set
        {
            premierDate = value;
            OnPropertyChanged();
        }
    }


    public void AddAndSave()
    {
        AddMovie();
        SaveToFile();
    }

    public void AddMovie()
    {

        Movie movie = new Movie
        {
            Title = Title,
            Duration = Duration,
            Genre = Genre,
            Director = Director,
            PremierDate = PremierDate

        };


        if (String.IsNullOrEmpty(movie.Title) || movie.Duration <= 0 || String.IsNullOrEmpty(movie.Genre))
        {
            throw new ArgumentException("Title, duration, and genre cannot be empty");
        }
        else
        {
            movieRepo.Add(movie);
            MovieViewModel movieVM = new MovieViewModel(movie);
            MovieVMs.Add(movieVM);
        }

    }

    public void SaveToFile()
    {
        movieRepo.SaveToFile();
    }

    public void LoadFromFile()
    {
        movieRepo.LoadFromFile();
        MovieVMs.Clear();

        foreach (Movie movie in movieRepo.GetAll())
        {
            MovieVMs.Add(new MovieViewModel(movie));
        }
    }

    public bool CanAdd()
    {
        if (String.IsNullOrWhiteSpace(Title) || Duration <= 0 || String.IsNullOrWhiteSpace(Genre))
        {
            return false;
        }
        else
        {
            return true;
        }

    }

    public void BackToMain()
    { 
        MainWindow mainwinndow = new MainWindow();
        mainwinndow.Show();
        App.Current.Windows[0].Close();
    }
}
