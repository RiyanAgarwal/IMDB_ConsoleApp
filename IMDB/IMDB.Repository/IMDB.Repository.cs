using IMDB.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Repository
{
    public class IMDBRepository : IIMDBRepository
    {
        private readonly List<Movie> _movies;
        private List<string> _producers = new List<string>() { "James Mangold" };
        private List<string> _actors = new List<string>() { "Matt Damon", "Christian Bale" };

        public IMDBRepository()
        {
            _movies = new List<Movie>();
        }
        public void AddMovie(Movie movie)
        {
            _movies.Add(movie);
        }
        public List<Movie> GetMovies()
        {
            return _movies.ToList();
        }
        public List<string> GetActors()
        {
            return _actors.ToList();
        }
        public string GetActorByIndex(int index)
        {
            return _actors[index-1];
        }
        public string GetProducerByIndex(int index)
        {
            return _producers[index - 1];
        }
        public List<string> GetProducers()
        {
            return _producers.ToList();
        }

    }

}
