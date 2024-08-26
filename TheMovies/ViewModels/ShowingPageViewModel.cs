using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows;
using TheMovies.Models;
using TheMovies.MVVM;
using TheMovies.Persistence;

namespace TheMovies.ViewModels;

public class ShowingPageViewModel : ViewModelBase
{
    public ShowingRepo showingRepo;
    public MovieRepo movieRepo;
    public CinemaRepo cinemaRepo;


    public ObservableCollection<MovieViewModel> MovieVMs { get; set; }
    public ObservableCollection<Cinema> Cinemas { get; set; }
    public ObservableCollection<string> CinemaHalls { get; set; }



    //Commands.
    //public RelayCommand NameOfCommand => new RelayCommand(execute => { }, canExecute => { return true; });
    public RelayCommand AddAndSaveShowingCommand => new RelayCommand(execute => AddAndSaveShowing(), canExecute => CanAdd());


    public ShowingPageViewModel()
    {
        movieRepo = new MovieRepo();
        MovieVMs = new ObservableCollection<MovieViewModel>();
        LoadMoviesFromFile();

        cinemaRepo = new CinemaRepo();
        Cinemas = new ObservableCollection<Cinema>(cinemaRepo.GetAll());
        CinemaHalls = new ObservableCollection<string>();


        showingRepo = new ShowingRepo();


        SelectedCinema = Cinemas[0];
        UpdateHalls();

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


    // Cinema

    private Cinema selectedCinema;

    public Cinema SelectedCinema
    {
        get { return selectedCinema; }
        set
        {
            selectedCinema = value;

            OnPropertyChanged();

            UpdateHalls();

        }
    }


    private string selectedCinemaHall;

    public string SelectedCinemaHall
    {
        get { return selectedCinemaHall; }
        set { selectedCinemaHall = value; }
    }


    private MovieViewModel selectedMovie;
    public MovieViewModel SelectedMovie
    {
        get { return selectedMovie; }
        set
        {
            selectedMovie = value;
            OnPropertyChanged();

            UpdateMovieDetails();
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

    private string timeOfDay;

    public string TimeOfDay
    {
        get { return timeOfDay; }
        set
        {
            timeOfDay = value;
            OnPropertyChanged();
        }

    }


    private void UpdateHalls()
    {
        CinemaHalls.Clear();
        if (SelectedCinema != null)
        {
            foreach (string hall in SelectedCinema.CinemaHalls)
            {
                CinemaHalls.Add(hall);
            }
            
        }
        SelectedCinemaHall = SelectedCinema.CinemaHalls[0];
    }

    private void UpdateMovieDetails()
    {
        if (SelectedMovie != null)
            ShowingDuration = SelectedMovie.Duration + 30;
        else
            ShowingDuration = 0;
    }

    public bool UpdateSelectedDateWithTime()
    {     
        if (DateTime.TryParseExact(TimeOfDay, "HH:mm", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedTime))
        {
            // Use a temporary variable to avoid recursion
            DateTime newDate = SelectedDate.Date.Add(parsedTime.TimeOfDay);

            if (selectedDate != newDate)
            {
                SelectedDate = newDate;
                OnPropertyChanged(nameof(SelectedDate));
            }

            return true;
        }
        else
            return false;


    }

    public void AddAndSaveShowing()
    {
        AddShowing();
        SaveShowingToFile();
        ClearFields();
    }

    private void ClearFields()
    {
        SelectedMovie = null;
        ShowingDuration = 0;
        TimeOfDay = "12:00";
        SelectedDate = DateTime.Now;
        SelectedCinema = Cinemas[0];
        SelectedCinemaHall = CinemaHalls[0];
    }


    /// <summary>
    /// Creates a Showing object from the chosen input in ShowingPageWindow
    /// </summary>
    /// <exception cref="ArgumentException"></exception>
    public void AddShowing()
    {
        // Konverter SelectedMovie (MovieViewModel til Movie)
        MovieViewModel movieViewModel = SelectedMovie;
        Movie movie = new Movie()
        {
            Title = movieViewModel.Title,
            Genre = movieViewModel.Genre,
            Director = movieViewModel.Director,
            Duration = movieViewModel.Duration,
            PremierDate = movieViewModel.PremierDate
        };


        Showing showing = new Showing()
        {
            Movie = movie,
            Cinema = SelectedCinema,
            CinemaHall = SelectedCinemaHall,
            ShowingDuration = ShowingDuration, //lægger 30 min til inden den saves til fil
            ShowingDate = (DateTime)SelectedDate
        };



        if (showing == null)
        {
            throw new ArgumentException("Movie, Cinema, CinemaHall, ShowingDuration and ShowingDate can't be empty!");
        }
        else
        {
            showingRepo.Add(showing);
        }

    }

    public void SaveShowingToFile()
    {
        showingRepo.SaveToFile();
    }

    public void LoadMoviesFromFile()
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
        if (SelectedMovie == null || ShowingDuration <= 0 || SelectedCinema == null || String.IsNullOrEmpty(TimeOfDay) || SelectedCinemaHall == null || UpdateSelectedDateWithTime() != true || SelectedDate < DateTime.Today)
            return false;
        else
            return true;
    }


}
