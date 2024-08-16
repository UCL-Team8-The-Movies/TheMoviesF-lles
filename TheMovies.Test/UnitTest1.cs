using TheMovies;
using TheMovies.Models;
using TheMovies.Persistence;
using TheMovies.ViewModels;

namespace TheMovies.Test;

[TestClass]
public class UnitTest1
{

    Movie movie1 = new Movie();
    Movie movie2 = new Movie();
    Movie movie3 = new Movie();


    [TestInitialize]
    public void SetupForTest()
    {
        MovieViewModel movieViewModel1 = new MovieViewModel(movie1)
        {
            Title = "Dr.DooLittle",
            Duration = 90,
            Genre = "Family"

        };
        MovieViewModel movieViewModel2 = new MovieViewModel(movie2)
        {
            Title = "Lord of The Rings",
            Duration = 90,
            Genre = "Fantasy"
        };
        MovieViewModel movieViewModel3 = new MovieViewModel(movie3)
        {
            Duration = 120,
            Genre = "Action"
        };

    }

    [TestMethod]
    public void AddMovie()
    {
        MovieRepo movierepo = new MovieRepo();

        movie1.Title = "hej";
        movie1.Duration = 120;
        movie1.Genre = "action";

        movierepo.Add(movie1);
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
    public void AddMovieWithoutTitle()
    {
     
        movie2.Duration = 98;
        movie2.Genre = "Drama";

    }
}