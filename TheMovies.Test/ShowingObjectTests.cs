using TheMovies.Models;
using TheMovies.Persistence;
using TheMovies.ViewModels;

namespace TheMovies.Test;

[TestClass]
public class ShowingObjectTests
{
    IRepo<Showing> showingrepo = new ShowingRepo();
    Showing showing = new Showing();

    ShowingPageViewModel SPVM = new ShowingPageViewModel();

    Movie movie = new Movie()
    {
        Title = "hej",
        Duration = 120,
        Genre = "action",
        Director = "John Smith",
        PremierDate = new DateTime(2024, 8, 28, 2, 30, 00),
    };



    [TestInitialize]
    public void InititializeMyTests()
    {
        showing = new Showing()
        {
            Movie = new Movie()
            {
                Title = "hej",
                Duration = 120,
                Genre = "action",
                Director = "John Smith",
                PremierDate = new DateTime(2024, 8, 28, 2, 30, 00)
            },

            Cinema = new Cinema()
            {
                Name = "CineMaxx",
                City = "Aarhus",
                MaxCinemaHall = 2,
                CinemaHalls = new List<string> { "Sal1", "Sal2" }
            },

            CinemaHall = "Sal1",
            ShowingDuration = 190,
            ShowingDate = new DateTime(2024, 8, 28, 2, 30, 00)

        };

        SPVM = new ShowingPageViewModel()
        {
            ShowingDuration = 180,
            ShowingDate = new DateTime(2024, 8, 28, 2, 30, 00),
            SelectedCinema = new Cinema()
            {
                Name = "CineMaxx",
                City = "Odense",
                MaxCinemaHall = 3,
                CinemaHalls = new List<string>
                {
                    "Sal1",
                    "Sal2",
                    "Sal3"
                }
            },
            SelectedCinemaHall = "Sal3",
            SelectedMovie = new MovieViewModel(movie),
            SelectedDate = new DateTime(2024, 8, 28, 2, 30, 00),
            TimeOfDay = "10:00"
        };
    }


    [TestMethod]
    public void AddShowingMethodInShowingRepo()
    {
        //Tilf�jer film til showingrepo
        showingrepo.Add(showing);
        var showings = showingrepo.GetAll();
        List<Showing> showingList = showings.ToList();

        //Assert Movie Object
        Assert.AreEqual("hej", showingList[0].Movie.Title);
        Assert.AreNotEqual("hello", showingList[0].Movie.Title);

        Assert.AreEqual(120, showingList[0].Movie.Duration);
        Assert.AreNotEqual(90, showingList[0].Movie.Duration);

        Assert.AreEqual("action", showingList[0].Movie.Genre);
        Assert.AreNotEqual("ation", showingList[0].Movie.Genre);

        Assert.AreEqual("John Smith", showingList[0].Movie.Director);
        Assert.AreNotEqual("Jesper Hansen", showingList[0].Movie.Director);

        Assert.AreEqual(new DateTime(2024, 8, 28, 2, 30, 00), showingList[0].Movie.PremierDate);
        Assert.AreNotEqual(new DateTime(2004, 8, 28, 4, 45, 36), showingList[0].Movie.PremierDate);



        // Assert Cinema Object
        Assert.AreEqual("CineMaxx", showingList[0].Cinema.Name);
        Assert.AreNotEqual("Nordic Film", showingList[0].Cinema.Name);

        Assert.AreEqual("Aarhus", showingList[0].Cinema.City);
        Assert.AreNotEqual("Odense", showingList[0].Cinema.City);

        Assert.AreEqual(2, showingList[0].Cinema.MaxCinemaHall);
        Assert.AreNotEqual(10, showingList[0].Cinema.MaxCinemaHall);

        Assert.AreEqual("Sal1", showingList[0].Cinema.CinemaHalls[0]);
        Assert.AreNotEqual("Sal2", showingList[0].Cinema.CinemaHalls[0]);



        //Assert CinemaHall
        Assert.AreEqual("Sal1", showingList[0].CinemaHall);
        Assert.AreNotEqual("Sal2", showingList[0].CinemaHall);

        //Assert ShowingDuration
        Assert.AreEqual(190, showingList[0].ShowingDuration);
        Assert.AreNotEqual(220, showingList[0].ShowingDuration);

        //Assert ShowingDate
        Assert.AreEqual(new DateTime(2024, 8, 28, 2, 30, 00), showingList[0].ShowingDate);
        Assert.AreNotEqual(new DateTime(2026, 10, 12, 5, 30, 00), showingList[0].ShowingDate);


    }

    //[TestMethod]
    //public void AddShowingMethodInShowingPageViewModel()
    //{
       

    //    SPVM.showingRepo.RemoveAll();

    //    //Tilf�j showing til ShowingPageViewModel's showingrepo
    //    SPVM.AddShowing();

    //    //retunerer IEnumerable med alle film i ShowingPageViewModel's showingrepo
    //    var showings = SPVM.showingRepo.GetAll();

    //    //Konvert�r IEnumerable til List
    //    List<Showing> showingList = showings.ToList();

    //    Assert.AreEqual("hej", showingList[0].Title);
    //    Assert.AreNotEqual("hello", showingList[0].Movie.Title);

    //    Assert.AreEqual(120, showingList[0].Duration);
    //    Assert.AreNotEqual(90, showingList[0].Duration);

    //    Assert.AreEqual("action", showingList[0].Genre);
    //    Assert.AreNotEqual("ation", showingList[0].Genre);

    //    Assert.AreEqual("John Smith", showingList[0].Director);
    //    Assert.AreNotEqual("Jesper Hansen", showingList[0].Director);

    //    Assert.AreEqual(new DateTime(2024, 8, 28, 2, 30, 00), showingList[0].PremierDate);
    //    Assert.AreNotEqual(new DateTime(2004, 8, 28, 4, 45, 36), showingList[0].PremierDate);

    //}

    //[TestMethod]
    //public void AddMovieWithoutTitle_CheckForException()
    //{

    //    MoviePageViewModel moviePageViewModel = new MoviePageViewModel();

    //    moviePageViewModel.Title = null;
    //    moviePageViewModel.Duration = 120;
    //    moviePageViewModel.Genre = "action";
    //    moviePageViewModel.Director = "John Smith";
    //    moviePageViewModel.PremierDate = new DateTime(2024, 8, 28, 2, 30, 00);


    //    Assert.ThrowsException<ArgumentException>(() => moviePageViewModel.AddMovie());

    //}

    //[TestMethod]
    //public void SaveAndLoadFromCsvFile()
    //{

    //    Movie movie1 = new Movie()
    //    {
    //        Title = "hej",
    //        Duration = 120,
    //        Genre = "action",
    //        Director = "John Smith",
    //        PremierDate = new DateTime(2024, 8, 28, 2, 30, 00)
    //    };
    //    Movie movie2 = new Movie()
    //    {
    //        Title = "Inception",
    //        Duration = 140,
    //        Genre = "Sci-Fi",
    //        Director = "Hans Hansen",
    //        PremierDate = new DateTime(2022, 9, 23, 5, 20, 00)

    //    };
    //    Movie movie3 = new Movie()
    //    {
    //        Title = "Tom and Jerry",
    //        Duration = 80,
    //        Genre = "Drama",
    //        Director = "Eric Ericson",
    //        PremierDate = new DateTime(2028, 6, 1, 3, 00, 00)
    //    };

    //    MovieRepo movieRepo1 = new MovieRepo();
    //    MovieRepo movieRepo2 = new MovieRepo();

    //    movieRepo1.Add(movie1);
    //    movieRepo1.Add(movie2);
    //    movieRepo1.Add(movie3);

    //    movieRepo1.SaveToFile();

    //    movieRepo2.LoadFromFile();

    //    List<Movie> moviesList1 = movieRepo1.GetAll().ToList();
    //    List<Movie> moviesList2 = movieRepo2.GetAll().ToList();

    //    Assert.AreEqual(moviesList1[0].Title, moviesList2[0].Title);
    //    Assert.AreEqual(moviesList1[0].Duration, moviesList2[0].Duration);
    //    Assert.AreEqual(moviesList1[0].Genre, moviesList2[0].Genre);
    //    Assert.AreEqual(moviesList1[0].Director, moviesList2[0].Director);
    //    Assert.AreEqual(moviesList1[0].PremierDate, moviesList2[0].PremierDate);

    //    Assert.AreEqual(moviesList1[1].Title, moviesList2[1].Title);
    //    Assert.AreEqual(moviesList1[1].Duration, moviesList2[1].Duration);
    //    Assert.AreEqual(moviesList1[1].Genre, moviesList2[1].Genre);
    //    Assert.AreEqual(moviesList1[1].Director, moviesList2[1].Director);
    //    Assert.AreEqual(moviesList1[1].PremierDate, moviesList2[1].PremierDate);

    //    Assert.AreEqual(moviesList1[2].Title, moviesList2[2].Title);
    //    Assert.AreEqual(moviesList1[2].Duration, moviesList2[2].Duration);
    //    Assert.AreEqual(moviesList1[2].Genre, moviesList2[2].Genre);
    //    Assert.AreEqual(moviesList1[2].Director, moviesList2[2].Director);
    //    Assert.AreEqual(moviesList1[2].PremierDate, moviesList2[2].PremierDate);
    //}



}
