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
                CinemaHalls = new List<string> { "Sal 1", "Sal 2" }
            },

            CinemaHall = "Sal 1",
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
                    "Sal 1",
                    "Sal 2",
                    "Sal 3"
                }
            },
            SelectedCinemaHall = "Sal 3",
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

        Assert.AreEqual("Sal 1", showingList[0].Cinema.CinemaHalls[0]);
        Assert.AreNotEqual("Sal 2", showingList[0].Cinema.CinemaHalls[0]);



        //Assert CinemaHall
        Assert.AreEqual("Sal 1", showingList[0].CinemaHall);
        Assert.AreNotEqual("Sal 2", showingList[0].CinemaHall);

        //Assert ShowingDuration
        Assert.AreEqual(190, showingList[0].ShowingDuration);
        Assert.AreNotEqual(220, showingList[0].ShowingDuration);

        //Assert ShowingDate
        Assert.AreEqual(new DateTime(2024, 8, 28, 2, 30, 00), showingList[0].ShowingDate);
        Assert.AreNotEqual(new DateTime(2026, 10, 12, 5, 30, 00), showingList[0].ShowingDate);


    }

    [TestMethod]
    public void AddShowingMethodInShowingPageViewModel()
    {

        SPVM.showingRepo.RemoveAll();

        //Tilf�j showing til ShowingPageViewModel's showingrepo
        SPVM.AddShowing();

        //retunerer IEnumerable med alle film i ShowingPageViewModel's showingrepo
        var showings = SPVM.showingRepo.GetAll();

        //Konvert�r IEnumerable til List
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

        Assert.AreEqual("Odense", showingList[0].Cinema.City);
        Assert.AreNotEqual("Aarhus", showingList[0].Cinema.City);

        Assert.AreEqual(3, showingList[0].Cinema.MaxCinemaHall);
        Assert.AreNotEqual(10, showingList[0].Cinema.MaxCinemaHall);

        Assert.AreEqual("Sal 1", showingList[0].Cinema.CinemaHalls[0]);
        Assert.AreNotEqual("Sal 2", showingList[0].Cinema.CinemaHalls[0]);



        //Assert CinemaHall
        Assert.AreEqual("Sal 3", showingList[0].CinemaHall);
        Assert.AreNotEqual("Sal 2", showingList[0].CinemaHall);

        //Assert ShowingDuration
        Assert.AreEqual(150, showingList[0].ShowingDuration);
        Assert.AreNotEqual(220, showingList[0].ShowingDuration);

        //Assert ShowingDate
        Assert.AreEqual(new DateTime(2024, 8, 28, 2, 30, 00), showingList[0].ShowingDate);
        Assert.AreNotEqual(new DateTime(2026, 10, 12, 5, 30, 00), showingList[0].ShowingDate);

        //Assert ShowingDuration is 30 longer than the Movie's Duration
        Assert.AreEqual(showingList[0].ShowingDuration, showingList[0].Movie.Duration + 30);

    }



    [TestMethod]
    public void SaveAndLoadFromCsvFile()
    {
    
        IRepo<Showing> showingRepo1 = new ShowingRepo();
        IRepo<Showing> showingRepo2 = new ShowingRepo();


        showingRepo1.RemoveAll();
        showingRepo1.LoadFromFile();
        showingRepo1.Add(showing);
        showingRepo1.SaveToFile();

        showingRepo2.LoadFromFile();

        List<Showing> showingList1 = showingRepo1.GetAll().ToList();
        List<Showing> showingList2 = showingRepo2.GetAll().ToList();




        Assert.AreEqual(showingList1.Count, showingList2.Count);
                  
        for (int i = 0; i < showingList1.Count; i++) 
        {
        
            Assert.AreEqual(showingList1[i].Movie.Title, showingList2[i].Movie.Title);
            Assert.AreEqual(showingList1[i].Movie.Duration, showingList2[i].Movie.Duration);
            Assert.AreEqual(showingList1[i].Movie.Genre, showingList2[i].Movie.Genre);
            Assert.AreEqual(showingList1[i].Movie.Director, showingList2[i].Movie.Director);
            Assert.AreEqual(showingList1[i].Movie.PremierDate, showingList2[i].Movie.PremierDate);

            Assert.AreEqual(showingList1[i].Cinema.Name, showingList2[i].Cinema.Name);
            Assert.AreEqual(showingList1[i].Cinema.City, showingList2[i].Cinema.City);
            Assert.AreEqual(showingList1[i].Cinema.MaxCinemaHall, showingList2[i].Cinema.MaxCinemaHall);
            int lastCinemaIndex = showingList1[i].Cinema.CinemaHalls.Count - 1;
            Assert.AreEqual(showingList1[i].Cinema.CinemaHalls[lastCinemaIndex], showingList2[i].Cinema.CinemaHalls[lastCinemaIndex]);

            Assert.AreEqual(showingList1[i].CinemaHall, showingList2[i].CinemaHall);
            Assert.AreEqual(showingList1[i].ShowingDuration, showingList2[i].ShowingDuration);
            Assert.AreEqual(showingList1[i].ShowingDate, showingList2[i].ShowingDate);
        
        }



    }



}
