using IMDB.Domain;

namespace IMDB.Repository
{
    public interface IIMDBRepository
    {
        void AddMovie(Movie movie);
        List<string> GetActors();
        List<Movie> GetMovies();
        List<string> GetProducers();
        string GetActorByIndex(int id);
        string GetProducerByIndex(int index);
    }
}