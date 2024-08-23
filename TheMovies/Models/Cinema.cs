namespace TheMovies.Models;

public class Cinema
{
    public string Name { get; set; }
    public string City { get; set; }

    //Ændrede fra list til string. Er der nemmere at hardcode at alle bigraferne har eks. 2 sale. (Det bliver svært at læse fra filen når det er en liste)
    public string CinemaHall { get; set; }
}
