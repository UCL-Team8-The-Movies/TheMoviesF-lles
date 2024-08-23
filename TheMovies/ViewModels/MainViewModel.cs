using System.Collections.ObjectModel;
using System.Windows;
using TheMovies.Models;
using TheMovies.MVVM;
using TheMovies.Persistence;

namespace TheMovies.ViewModels;

public class MainViewModel : ViewModelBase
{
    public CinemaRepo cinemaRepo;
    public ShowingRepo showingRepo;

    public ObservableCollection<ShowingViewModel> ShowingVMs { get; set; }

    //Commands.
    //public RelayCommand NameOfCommand => new RelayCommand(execute => { }, canExecute => { return true; });
    


    public MainViewModel()
    {
        cinemaRepo = new CinemaRepo();
        showingRepo = new ShowingRepo();
        ShowingVMs = [];
        LoadFromFile();
    }

    private Cinema cinema;

    public Cinema Cinema
    {
        get { return cinema; }
        set { cinema = value; }
    }


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

    private string showingDate;

    public string ShowingDate
    {
        get { return showingDate; }
        set
        {
            showingDate = value;
            OnPropertyChanged();
        }
    }


    public void LoadFromFile()
    {
        showingRepo.LoadFromFile();
        ShowingVMs.Clear();

        foreach (Showing showing in showingRepo.GetAll())
        {
            ShowingVMs.Add(new ShowingViewModel(showing));
        }
    }

 
}
