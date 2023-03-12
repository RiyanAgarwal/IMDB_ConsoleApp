using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using IMDB.Domain;
using IMDB.Repository;
using System.Linq;
namespace IMDB.Service
{
    public class IMDBService :IIMDBService
    {
        private readonly IIMDBRepository _repository;

        public IMDBService()
        {
            _repository = new IMDBRepository();
        }
        public List<string> ShowListOfActorsOrProducers(bool b)
        {
           throw new NotImplementedException(); 
        }
        public List<string> ChosenActors(string index)
        {
          throw new NotImplementedException();
        }
        public string ChosenProducer(int index)
        {
       throw new NotImplementedException();
        }
        public void Add(int yearOfRelease, string name, string plot, string producer, List<string> actors)
        {
            _repository.AddMovie(new Movie(yearOfRelease, name, plot, producer, actors));      
        }
        
        public List<Movie> Get()
        {
            throw new NotImplementedException();
        }
        public string ListMovies()
        {
           throw new NotImplementedException(); 
        }
        public List<string> ListAllMovieNamesAfterCertainYear(int year)
        {
            var list = from movie in _repository.GetMovies()
                       where movie.YearOfRelease>year
                       select movie.Name;
            return list.ToList();
        }
        public List<string> ListAllMovieNamesAndYear(bool b)
        {
            if (b.Equals(true))
            {
                var list = from movie in _repository.GetMovies()
                           orderby movie.YearOfRelease  ascending
                           select $"{movie.Name} - {movie.YearOfRelease}";
                return list.ToList();
            }
            else
            {
                var list = from movie in _repository.GetMovies()
                           select movie.Name;
                return list.ToList();
            }
        }
        public string LatestMovieWhoseNameContains(string word)
        {
            var moviesContainingWord=from movie in _repository.GetMovies()
                          orderby movie.YearOfRelease descending
                          where movie.Name.Contains(word)
                          select movie.Name;
            return moviesContainingWord.ToList()[0];
        }
        public List<string> ListAllMoviesWithActor(string actor)
        {
            var list = from movie in _repository.GetMovies()
                       where movie.Actors.Contains(actor)
                       select movie.Name;
            return list.ToList();
        }

    }
}
