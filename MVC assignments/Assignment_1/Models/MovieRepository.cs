namespace Assignment_1.Models
{
    public class MovieRepository
    {
        static List<Movie> movies= new List<Movie>();
        public List<Movie> GetAllMovies()
        {
            return movies;
        }
        public Movie GetMovieByName(string name)
        {
            foreach(Movie item in movies)
            {
                if(item.Title.Equals(name))
                    return item;
            }
            return null;
        }
        public void Add(Movie movie) 
        { 
            movies.Add(movie);
        }
    }
}
