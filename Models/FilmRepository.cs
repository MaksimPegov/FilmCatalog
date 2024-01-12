namespace FilmCatalog.Models;

public static class FilmRepository
{
    private static List<Film> films = new List<Film>()
    {
        new Film(
            "The Godfather", 
            "Francis Ford Coppola", 
            1972,
            "https://m.media-amazon.com/images/M/MV5BM2MyNjYxNmUtYTAwNi00MTYxLWJmNWYtYzZlODY3ZTk3OTFlXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_FMjpg_UX1000_.jpg",
            "The aging patriarch of an organized crime dynasty transfers control of his clandestine empire to his reluctant son.",
            new List<Comment>()
            {
                new Comment { Text = "Great movie!", Rating = 9 },
                new Comment { Text = "Enjoyed it a lot.", Rating = 8 },
                new Comment { Text = "Not bad.", Rating = 6 }
            }
        ),
        new Film(
            "The Dark Knight", 
            "Christopher Nolan", 
            2008, 
            "https://m.media-amazon.com/images/M/MV5BMTMxNTMwODM0NF5BMl5BanBnXkFtZTcwODAyMTk2Mw@@._V1_.jpg",
            "When the menace known as the Joker wreaks havoc and chaos on the people of Gotham, Batman must accept one of the greatest psychological and physical tests of his ability to fight injustice.",
            new List<Comment>()
            {
                new Comment { Text = "I am vengeance.", Rating = 9 },
                new Comment { Text = "I am sigma now...", Rating = 10 },
            }
        ),
        new Film(
            "Fight Club",
            "David Fincher",
            1999, 
            "https://m.media-amazon.com/images/I/51v5ZpFyaFL._AC_.jpg",
            "An insomniac office worker and a devil-may-care soapmaker form an underground fight club that evolves into something much, much more.",
            new List<Comment>()
            {
                new Comment { Text = "Brad Pit is SUUUUS!", Rating = 10 },
                new Comment { Text = "Enjoyed it a lot.", Rating = 8 },
                new Comment { Text = "His name is Robert Polson...", Rating = 6 }
            }
        )
    };

    public static void AddFilm(Film film)
    {
        films.Add(film);
    }

    public static List<Film> GetFilms()
    {
        return films;
    }

    public static void RemoveFilm(string filmName)
    {
        films.Remove(films.FirstOrDefault(f => f.Title == filmName));
    }
    
    public static Film GetFilm(string title)
    {
        return films.FirstOrDefault(f => f.Title == title);
    }
    
    public static void AddComment(string filmName, Comment comment)
    {
        films.FirstOrDefault(f => f.Title == filmName)?.AddComment(comment);
    }
    
    public static Film GetFilmByTitle(string title)
    {
        return films.FirstOrDefault(f => f.Title == title);
    }
}