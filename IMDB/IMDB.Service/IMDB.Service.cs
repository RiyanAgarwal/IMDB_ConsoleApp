using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using IMDB.Domain;
using IMDB.Repository;

namespace IMDB.Service
{
    public class IMDBService : IIMDBService
    {
        private readonly IIMDBRepository _repository;

        public IMDBService(IIMDBRepository iMDBRepository)
        {
            _repository = iMDBRepository;
        }
        public void AddActorOrProducer(string name, DateOnly date, bool b)
        {
            _repository.AddProducerOrActor(name, date, b);
        }
        public List<Person> ShowListOfActorsOrProducers(bool b)
        {
            if (b)
            {
                return _repository.GetActors();
            }
            else
            {
                return _repository.GetProducers();
            }
        }
        public List<Person> ChosenActors(string index)
        {
            var numberOActors = _repository.GetActors().Count();

            var intList = index.Split(' ').Select(int.Parse).ToList();

            if (numberOActors < intList.Max())
                return new List<Person>();
            var actorList = new List<Person>();
            foreach (var integer in intList)
            {
                actorList.Add(_repository.GetActorByIndex(integer));
            }
            return actorList;
        }
        public Person ChosenProducer(int index)
        {
            var numberOfProducers = _repository.GetProducers().Count();
            if (index <= numberOfProducers)
                return _repository.GetProducerByIndex(index);
            else
                return new Person();
        }
        public void Add(int yearOfRelease, string name, string plot, Person producer, List<Person> actors)
        {
            if (actors.Count() == 0 || string.IsNullOrWhiteSpace(producer.Name) || string.IsNullOrWhiteSpace(name) || string.IsNullOrWhiteSpace(plot) || yearOfRelease > DateTime.Today.Year || yearOfRelease < 1800)
            {
                throw new ArgumentException("Invalid data");
            }
            else
            {
                _repository.AddMovie(new Movie(yearOfRelease, name, plot, producer, actors));
            }
        }
        public void DeleteMovie(int index)
        {
            _repository.RemoveMovie(index);
        }
        public List<Movie> Get()
        {
            return _repository.GetMovies();
        }
        public string ListMovies()
        {
            var list = from movie in _repository.GetMovies()
                       select $"{movie.Name} ({movie.YearOfRelease})\r\nPlot - {movie.Plot}\r\nActors - {string.Join(", ", movie.Actors.Select(person => person.Name).ToList())}\r\nProducers - {movie.Producer.Name}";
            return string.Join("\n\n", list);

        }

    }
}
