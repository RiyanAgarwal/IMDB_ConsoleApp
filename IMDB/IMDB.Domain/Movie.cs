using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Domain
{
    public class Person
    {
        public string Name { get; set; }
        public DateOnly DateOfBirth{ get; set; }
        public Person( string name, DateOnly dateTime)
        {
            Name = name;
            DateOfBirth = dateTime;
        }
        public Person() { }
    }
    public class Movie
    {
        public int YearOfRelease { get; set; }
        public string Name { get; set; }
        public string Plot { get; set; }
        public Person Producer { get; set; }
        public List<Person> Actors { get; set; }
        public Movie(int yearOfRelease, string name, string plot, Person producer, List<Person> actors)
        {
            YearOfRelease = yearOfRelease;
            Name = name;
            Plot = plot;
            Producer = producer;
            Actors = actors;
        }
    }
}
