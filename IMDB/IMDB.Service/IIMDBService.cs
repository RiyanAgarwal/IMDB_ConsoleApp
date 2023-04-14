using IMDB.Domain;

namespace IMDB.Service
{
    public interface IIMDBService
    {
        void Add(int yearOfRelease, string name, string plot, Person producer, List<Person> actors);
        void AddActorOrProducer(string name, DateOnly date, bool b);
        List<Person> ChosenActors(string index);
        Person ChosenProducer(int index);
        void DeleteMovie(int index);
        List<Movie> Get();
        string ListMovies();
        List<Person> ShowListOfActorsOrProducers(bool b);
    }
}