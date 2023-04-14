using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB.Domain
{
        public class Movie
        {
            public int YearOfRelease { get; set; }

            public string Name { get; set; }
            public string Plot { get; set; }
            public string Producer { get; set; }
            public List<string> Actors { get; set; }

            public Movie(int yearOfRelease, string name, string plot, string producer, List<string> actors)
            {
                YearOfRelease = yearOfRelease;
                Name = name;
                Plot = plot;
                Producer = producer;
                Actors = actors;
            }
        }
}
