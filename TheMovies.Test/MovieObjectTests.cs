using TheMovies.Models;
using TheMovies.Persistence;
using TheMovies.ViewModels;

namespace TheMovies.Test;


[TestClass]
public class MovieObjectTests
{

    [TestMethod]
    public void AddMovieMethodInMovieRepo()
    {
        IRepo<Movie> movierepo = new MovieRepo();
        Movie movie = new Movie();

        movie.Title = "hej";
        movie.Duration = 120;
        movie.Genre = "action";
        movie.Director = "John Smith";
        movie.PremierDate = new DateTime(2024, 8, 28, 2, 30, 00);

        //Tilf�jer film til movierepo
        movierepo.Add(movie);
        var movies = movierepo.GetAll();
        List<Movie> movieList = movies.ToList();

        Assert.AreEqual("hej", movieList[0].Title);
        Assert.AreNotEqual("hello", movieList[0].Title);

        Assert.AreEqual(120, movieList[0].Duration);
        Assert.AreNotEqual(90, movieList[0].Duration);

        Assert.AreEqual("action", movieList[0].Genre);
        Assert.AreNotEqual("ation", movieList[0].Genre);

        Assert.AreEqual("John Smith", movieList[0].Director);
        Assert.AreNotEqual("Jesper Hansen", movieList[0].Director);

        Assert.AreEqual(new DateTime(2024, 8, 28, 2, 30, 00), movieList[0].PremierDate);
        Assert.AreNotEqual(new DateTime(2004, 8, 28, 4, 45, 36), movieList[0].PremierDate);
    }

    [TestMethod]
    public void AddMovieMethodInMovieViewModel()
    {   
        MoviePageViewModel moviePageViewModel = new MoviePageViewModel();

        moviePageViewModel.Title = "hej";
        moviePageViewModel.Duration = 120;
        moviePageViewModel.Genre = "action";
        moviePageViewModel.Director = "John Smith";
        moviePageViewModel.PremierDate = new DateTime(2024, 8, 28, 2, 30, 00);

        moviePageViewModel.movieRepo.RemoveAll();

        //Tilf�j film til MoviePageViewModel's movierepo
        moviePageViewModel.AddMovie();

        //retunerer IEnumerable med alle film i MoviePageViewModel's movierepo
        var movies = moviePageViewModel.movieRepo.GetAll();

        //Konvert�r IEnumerable til List
        List<Movie> movieList = movies.ToList();

        Assert.AreEqual("hej", movieList[0].Title);
        Assert.AreNotEqual("hello", movieList[0].Title);

        Assert.AreEqual(120, movieList[0].Duration);
        Assert.AreNotEqual(90, movieList[0].Duration);

        Assert.AreEqual("action", movieList[0].Genre);
        Assert.AreNotEqual("ation", movieList[0].Genre);

        Assert.AreEqual("John Smith", movieList[0].Director);
        Assert.AreNotEqual("Jesper Hansen", movieList[0].Director);

        Assert.AreEqual(new DateTime(2024, 8, 28, 2, 30, 00), movieList[0].PremierDate);
        Assert.AreNotEqual(new DateTime(2004, 8, 28, 4, 45, 36), movieList[0].PremierDate);

    }

    [TestMethod]
    public void AddMovieWithoutTitle_CheckForException()
    {

        MoviePageViewModel moviePageViewModel = new MoviePageViewModel();

        moviePageViewModel.Title = null;
        moviePageViewModel.Duration = 120;
        moviePageViewModel.Genre = "action";
        moviePageViewModel.Director = "John Smith";
        moviePageViewModel.PremierDate = new DateTime(2024, 8, 28, 2, 30, 00);


        Assert.ThrowsException<ArgumentException>(() => moviePageViewModel.AddMovie());

    }

    [TestMethod]
    public void SaveAndLoadFromCsvFile()
    {

        Movie movie1 = new Movie()
        {
            Title = "hej",
            Duration = 120,
            Genre = "action",
            Director = "John Smith",
            PremierDate = new DateTime(2024, 8, 28, 2, 30, 00)
        };
        Movie movie2 = new Movie()
        {
            Title = "Inception",
            Duration = 140,
            Genre = "Sci-Fi",
            Director = "Hans Hansen",
            PremierDate = new DateTime(2022, 9, 23, 5, 20, 00)

        };
        Movie movie3 = new Movie()
        {
            Title = "Tom and Jerry",
            Duration = 80,
            Genre = "Drama",
            Director = "Eric Ericson",
            PremierDate = new DateTime(2028, 6, 1, 3, 00, 00)
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
        Assert.AreEqual(moviesList1[0].Director, moviesList2[0].Director);
        Assert.AreEqual(moviesList1[0].PremierDate, moviesList2[0].PremierDate);

        Assert.AreEqual(moviesList1[1].Title, moviesList2[1].Title);
        Assert.AreEqual(moviesList1[1].Duration, moviesList2[1].Duration);
        Assert.AreEqual(moviesList1[1].Genre, moviesList2[1].Genre);
        Assert.AreEqual(moviesList1[1].Director, moviesList2[1].Director);
        Assert.AreEqual(moviesList1[1].PremierDate, moviesList2[1].PremierDate);

        Assert.AreEqual(moviesList1[2].Title, moviesList2[2].Title);
        Assert.AreEqual(moviesList1[2].Duration, moviesList2[2].Duration);
        Assert.AreEqual(moviesList1[2].Genre, moviesList2[2].Genre);
        Assert.AreEqual(moviesList1[2].Director, moviesList2[2].Director);
        Assert.AreEqual(moviesList1[2].PremierDate, moviesList2[2].PremierDate);
    }


    
}


