using TheMovies;
using TheMovies.Models;
using TheMovies.Persistence;
using TheMovies.ViewModels;

namespace TheMovies.Test;

[TestClass]
public class UnitTest1
{

    [TestMethod]
    public void AddMovieMethodInMovieRepo()
    {
        MovieRepo movierepo = new MovieRepo();
        Movie movie = new Movie();
        
        movie.Title = "hej";
        movie.Duration = 120;
        movie.Genre = "action";

        //Tilføjer film til movierepo
        movierepo.Add(movie);
        var movies = movierepo.GetAll();
        List<Movie> movieList = movies.ToList();

        Assert.AreEqual("hej", movieList[0].Title);
        Assert.AreNotEqual("hello", movieList[0].Title);

        Assert.AreEqual(120, movieList[0].Duration);
        Assert.AreNotEqual(90, movieList[0].Duration);

        Assert.AreEqual("action", movieList[0].Genre);
        Assert.AreNotEqual("ation", movieList[0].Genre);

    }

    [TestMethod]
    public void AddMovieMethodInMainViewModel()
    {
        MainViewModel mainViewModel = new MainViewModel();

        mainViewModel.Title = "hej";
        mainViewModel.Duration = 120;
        mainViewModel.Genre = "action";

        mainViewModel.movieRepo.ClearMovies();

        //Tilføj film til mainviewmodels movierepo
        mainViewModel.AddMovie();

        //retunerer IEnumerable med alle film i mvm's movierepo
        var movies = mainViewModel.movieRepo.GetAll();

        //Konvertér IEnumerable til List
        List<Movie> movieList = movies.ToList();

        Assert.AreEqual("hej", movieList[0].Title);
        Assert.AreNotEqual("hello", movieList[0].Title);

        Assert.AreEqual(120, movieList[0].Duration);
        Assert.AreNotEqual(90, movieList[0].Duration);

        Assert.AreEqual("action", movieList[0].Genre);
        Assert.AreNotEqual("ation", movieList[0].Genre);

    }

    [TestMethod]
    public void AddMovieWithoutTitle_CheckForException()
    {

        MainViewModel mainViewModel = new MainViewModel();

        mainViewModel.Title = null;
        mainViewModel.Duration = 120;
        mainViewModel.Genre = "action";

        mainViewModel.movieRepo.ClearMovies();


        Assert.ThrowsException<ArgumentException>(() => mainViewModel.AddMovie());

    }

    [TestMethod]
    public void SaveAndLoadFromCsvFile()
    {

        Movie movie1 = new Movie()
        {
            Title = "hej",
            Duration = 120,
            Genre = "action"
        };
        Movie movie2 = new Movie()
        {
            Title = "Inception",
            Duration = 140,
            Genre = "Sci-Fi"
        };
        Movie movie3 = new Movie()
        {
            Title = "Tom and Jerry",
            Duration = 80,
            Genre = "Drama"
        };

        MovieRepo movieRepo1 = new MovieRepo();
        MovieRepo movieRepo2 = new MovieRepo();

        movieRepo1.Add(movie1);
        movieRepo1.Add(movie2);
        movieRepo1.Add(movie3);

        movieRepo1.SaveToFile();

        movieRepo2.LoadFromFile();

        List<Movie> moviesList1 = movieRepo1.GetAll().ToList();
        List<Movie> moviesList2 = movieRepo2.GetAll().ToList();

        Assert.AreEqual(moviesList1[0].Title, moviesList2[0].Title);
        Assert.AreEqual(moviesList1[0].Duration, moviesList2[0].Duration);
        Assert.AreEqual(moviesList1[0].Genre, moviesList2[0].Genre);

        Assert.AreEqual(moviesList1[1].Title, moviesList2[1].Title);
        Assert.AreEqual(moviesList1[1].Duration, moviesList2[1].Duration);
        Assert.AreEqual(moviesList1[1].Genre, moviesList2[1].Genre);
        
        Assert.AreEqual(moviesList1[2].Title, moviesList2[2].Title);
        Assert.AreEqual(moviesList1[2].Duration, moviesList2[2].Duration);
        Assert.AreEqual(moviesList1[2].Genre, moviesList2[2].Genre);

    }


}