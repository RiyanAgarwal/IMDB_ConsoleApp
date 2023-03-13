using IMDB.Domain;

namespace IMDB.Service
{
    public interface IIMDBService
    {
       
        void Add(int yearOfRelease, string name, string plot, string producer, List<string> actors);
        List<string> ChosenActors(string index);
        string ChosenProducer(int index);
        List<Movie> Get();
        List<string> ShowListOfActorsOrProducers(bool b);
        string ListMovies();
    }
}