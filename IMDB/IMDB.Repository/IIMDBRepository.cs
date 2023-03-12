using IMDB.Domain;

namespace IMDB.Repository
{
    public interface IIMDBRepository
    {
        void AddMovie(Movie movie);
        void AddProducerOrActor(string name, DateOnly date, bool b);
        Person GetActorByIndex(int index);
        List<Person> GetActors();
        List<Movie> GetMovies();
        Person GetProducerByIndex(int index);
        List<Person> GetProducers();
        void RemoveMovie(int index);
    }
}