using System.Windows;
using TheMovies.ViewModels;

namespace TheMovies.Views;

/// <summary>
/// Interaction logic for MoviePageWindow.xaml
/// </summary>
public partial class MoviePageWindow : Window
{
    public MoviePageWindow()
    {
        InitializeComponent();
        MoviePageViewModel MPVM = new MoviePageViewModel();
        DataContext = MPVM;
    }
}
