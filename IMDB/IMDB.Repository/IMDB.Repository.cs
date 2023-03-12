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
        private readonly List<Person> _producers = new List<Person>();
        private readonly List<Person> _actors = new List<Person>();

        public IMDBRepository()
        {
            _movies = new List<Movie>();
        }
        public void AddMovie(Movie movie)
        {
            _movies.Add(movie);
        }
        public void AddProducerOrActor(string name, DateOnly date, bool b)
        {
            if (b)
            {
                _actors.Add(new Person(name, date));
            }
            else
            {
                _producers.Add(new Person(name, date));
            }
        }
        public void RemoveMovie(int index)
        {
            try
            {
                _movies.RemoveAt(index - 1);
            }
            catch (Exception e)
            {
                Console.WriteLine("Invalid index");
            }
        }
        public List<Movie> GetMovies()
        {
            return _movies.ToList();
        }
        public List<Person> GetActors()
        {
            return _actors.ToList();
        }
        public Person GetActorByIndex(int index)
        {
            return _actors[index - 1];
        }
        public Person GetProducerByIndex(int index)
        {
            return _producers[index - 1];
        }
        public List<Person> GetProducers()
        {
            return _producers.ToList();
        }

    }

}
