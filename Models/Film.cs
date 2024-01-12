using System.Collections;

namespace FilmCatalog.Models
{
    public class Film
    {
        public string Title { get; set; }
        public string Director { get; set; }
        public int Year { get; set; }
        
        public double Rating { get; set; }
        
        public string ImageUrl { get; set; }
        
        public string Description { get; set; }
        
        public List<Comment> _comments = new List<Comment>();
        
        private List<double> Ratings = new List<double>();
        
        public void AddComment(Comment comment)
        {
            _comments.Add(comment);
            Ratings.Add(comment.Rating);
            Rating = Math.Round(Ratings.Average(), 1);
        }
        
        public Film( string title, string director, int year, string imageUrl, string description)
        {
            Title = title;
            Director = director;
            Year = year;
            Rating = 0;
            ImageUrl = imageUrl;
            Description = description;
        }
        
        public Film( string title, string director, int year, string imageUrl, string description, List<Comment> comments)
        {
            Title = title;
            Director = director;
            Year = year;
            Rating = 0;
            ImageUrl = imageUrl;
            Description = description;
            _comments = comments;

            foreach (Comment comment in comments)
            {
                Ratings.Add(comment.Rating);
            }
            Rating = Math.Round(Ratings.Average(), 1);
        }
    }

}