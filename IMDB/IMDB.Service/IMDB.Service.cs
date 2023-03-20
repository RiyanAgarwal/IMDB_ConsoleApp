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
        public void AddActorOrProducer(string name, DateOnly date, bool isActor)
        {
            if(string.IsNullOrWhiteSpace(name)) 
            {
                throw new ArgumentException("Invalid name");    
            }
            if (date.Year > DateTime.Today.Date.Year||date.Year==2023)
            {
                throw new ArgumentException("Invalid date");
            }
            _repository.AddProducerOrActor(name, date, isActor);
        }
        public List<Person> ShowListOfActorsOrProducers(bool isActor)
        {
            if (isActor)
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
                throw new ArgumentException("Invalid actors");
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
                throw new ArgumentException("Invalid producer");
        }
        public void Add(int yearOfRelease, string name, string plot, Person producer, List<Person> actors)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Invalid name");
            }
            if (yearOfRelease > DateTime.Today.Year|| yearOfRelease<1800)
            {
                throw new InvalidDataException("Invalid year");
            }
            if (string.IsNullOrWhiteSpace(plot))
            {
                throw new ArgumentException("Invalid plot");
            }
            else
            {
                _repository.AddMovie(new Movie(yearOfRelease, name, plot, producer, actors));
            }
        }
        public void DeleteMovie(int index)
        {
            if (_repository.GetMovies().Count() < index||index<1)
                throw new ArgumentOutOfRangeException("Invalid Index");
            else
                _repository.RemoveMovie(index);
        }
        public List<Movie> Get()
        {   if (_repository.GetMovies().Count()>0)
                return _repository.GetMovies();
            throw new Exception( "Currently repository is empty");
        }
        public string ListMovies()
        {
            var list = from movie in _repository.GetMovies()
                       select $"{movie.Name} ({movie.YearOfRelease})\r\nPlot - {movie.Plot}\r\nActors - {string.Join(", ", movie.Actors.Select(person => person.Name).ToList())}\r\nProducers - {movie.Producer.Name}";
            return string.Join("\n\n", list);

        }

    }
}
