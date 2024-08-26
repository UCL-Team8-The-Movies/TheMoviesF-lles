using System.IO;
using TheMovies.Models;

namespace TheMovies.Persistence;

public class ShowingRepo : IRepo<Showing>
{
    private List<Showing> showings = [];
    private string filePath;

    public ShowingRepo()
    {
        this.filePath = Path.Combine(PathHelper.GetSolutionDirectory(), "Showings.csv");
    }


    public void Add(Showing showing)
    {
        this.showings.Add(showing);
    }

    public IEnumerable<Showing> GetAll()
    {
        return this.showings;
    }

    public void SaveToFile()
    {
        using (StreamWriter sw = new StreamWriter(filePath, true))
        {
            if (!File.Exists(this.filePath))           
                sw.WriteLine("Filmtitel;Filmvarighed;Filmgenre;Filninstruktr;Filmprmieredato;Biografnavn;Biografby;MaxBiografSale;Biografsal;Forestillingsvarighed;Forestillingsdato");

            foreach (Showing showing in showings)
            {
                sw.WriteLine($"{showing.Movie.Title};{showing.Movie.Duration};{showing.Movie.Genre};{showing.Movie.Director};{showing.Movie.PremierDate};{showing.Cinema.Name};{showing.Cinema.City};{showing.Cinema.MaxCinemaHall};{showing.CinemaHall};{showing.ShowingDuration};{showing.ShowingDate}");
            }
        }
    }

    public void LoadFromFile()
    {
        CheckForNonExistingFile();
        this.showings.Clear();

        using (StreamReader sr = new StreamReader(filePath))
        {
            string header = sr.ReadLine();

            string line;
            while ((line = sr.ReadLine()) != null)
            {

                string[] values = line.Split(';');

                int movieDuration;
                DateTime premierDate;
                int maxCinemaHalls;
                int showingDuration;
                DateTime showingDate;

                if (int.TryParse(values[1], out movieDuration) 
                    && DateTime.TryParse(values[4], out premierDate)
                    && int.TryParse(values[7], out maxCinemaHalls)
                    && int.TryParse(values[9], out showingDuration) 
                    && DateTime.TryParse(values[10], out showingDate))
                {

                    // Håndter Cinema objekt
                    Cinema cinema = new Cinema()
                    {
                        Name = values[5],
                        City = values[6],
                        MaxCinemaHall = maxCinemaHalls,
                        CinemaHalls = new List<string>()
                    };

                    // Tilføj en sal afhængig af hvad MaxCinemaHalls læses til at være
                    for (int i = 1; i <= cinema.MaxCinemaHall; i++)
                    {
                        cinema.CinemaHalls.Add($"Sal {i}");
                    }



                    // Håndter Showing objekt
                    this.showings.Add(new Showing()
                    {
                        Movie = new Movie()
                        {
                            Title = values[0],
                            Duration = movieDuration,
                            Genre = values[2],
                            Director = values[3],
                            PremierDate = premierDate
                        },
                        
                        //sæt Cinema attribute i Showingobjektet til ovenstående Cinema objekt
                        Cinema = cinema,
                        CinemaHall = values[8],
                        ShowingDuration = showingDuration,
                        ShowingDate = showingDate
                    }); 
                }

                else
                {
                    throw new FormatException("Error. Invalid format in file");
                }
            }
        }

    }


    public void CheckForNonExistingFile()
    {
        if (!File.Exists(filePath))
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine("Filmtitel;Filmvarighed;Filmgenre;Filninstruktør;Filmpræmieredato;Biografnavn;Biografby;Biografsal;Forestillingsvarighed;Forestillingsdato");
            }
        }
    }


    public void ClearShowings() => showings.Clear();

}
