using System.IO;
using TheMovies.Models;

namespace TheMovies.Persistence;

public class MovieRepo : IRepo<Movie>
{
    private List<Movie> movies = [];

    private string filePath;

    public MovieRepo()
    {
        this.filePath = Path.Combine(PathHelper.GetSolutionDirectory(), "Movies.csv");
    }

    public void Add(Movie movie)
    {
        movies.Add(movie);
    }

    public IEnumerable<Movie> GetAll()
    {
        return movies;
    }

    public void SaveToFile()
    {
        using (StreamWriter sw = new StreamWriter(filePath))
        {
            sw.WriteLine("Titel,Varighed,Genre");

            foreach (Movie movie in movies)
            {
                sw.WriteLine($"{movie.Title},{movie.Duration},{movie.Genre}");
            }

        }
    }

    public void LoadFromFile()
    {
        movies.Clear();

        using (StreamReader sr = new StreamReader(filePath))
        {
            string header = sr.ReadLine();

            string line;
            while ((line = sr.ReadLine()) != null)
            {

                string[] values = line.Split(',');
                int duration;

                if (int.TryParse(values[1], out duration))
                {
                    movies.Add(new Movie()
                    {
                        Title = values[0],
                        Duration = duration,
                        Genre = values[2]
                    });
                }
            }
        }

    }
        public void ClearMovies() => movies.Clear(); 







}
