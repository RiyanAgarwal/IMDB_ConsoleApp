using System;
using IMDB.Domain;
using IMDB.Service;

namespace IMDB

{
    class Program
    {
        static void Main(string[] args) 
        {
            var service=new IMDBService();
            //Sample movies added to perform further operations
            service.Add(2022,"The Avatar 2","A good action movie","James Cameron",new List<string>() { "Sam", "Stephen","Zoe" });
            service.Add(2009,"Harry Potter","A good fantasy movie","JKR",new List<string>() { "Daniel Redcliff", "Emma Watson" });
            service.Add(2016,"Suicide Squad","A good action movie","Charles Raven",new List<string>() { "Jared Leto", "Will Smith" });


            Console.WriteLine("All movies after year 2010:");
            foreach ( var movie in service.ListAllMovieNamesAfterCertainYear(2010))
            {
                Console.WriteLine(movie);
            }

            Console.WriteLine("\nList of all movies:");
            foreach (var movie in service.ListAllMovieNamesAndYear(false))
            {
                Console.WriteLine(movie);
            }


            Console.WriteLine("\nList of all movies with their year of release:");
            foreach (var movie in service.ListAllMovieNamesAndYear( true))
            {
                Console.WriteLine(movie);
            }

            Console.WriteLine("\nList of all movies in which Will Smith has acted");
            foreach (var movie in service.ListAllMoviesWithActor("Will Smith"))
            {
                Console.WriteLine(movie);
            }
        } 
    }
}




