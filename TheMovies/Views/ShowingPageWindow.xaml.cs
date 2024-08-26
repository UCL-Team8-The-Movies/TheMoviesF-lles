using System.Windows;
using TheMovies.ViewModels;

namespace TheMovies.Views;

/// <summary>
/// Interaction logic for ShowingPageWindow.xaml
/// </summary>
public partial class ShowingPageWindow : Window
{
    public ShowingPageWindow()
    {
        InitializeComponent();
        ShowingPageViewModel SPVM = new ShowingPageViewModel();
        DataContext = SPVM;
    }

}
