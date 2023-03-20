using IMDB;
using IMDB.Repository;
using IMDB.Service;
using IMDB.Domain;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using TechTalk.SpecFlow.Assist;
using System;

namespace IMDB.Tests.StepDefinitions
{
    [Binding]
    public sealed class IMDBStepDefinitions
    {
        private IIMDBService _service;
        private string _name, _plot,_message;
        private int _yearOfRelease;
        private string _actors;
        private string _producer;
        private Exception _exception;
        private List<Movie> _movies;
        public IMDBStepDefinitions()
        {
            _service = new IMDBService(new IMDBRepository());
        }

        [Given(@"the movie has name ""(.*)""")]
        public void GivenTheMovieNameIs(string name)
        {
            _name = name;
        }

        [Given(@"the year of release is ""(.*)""")]
        public void GivenTheYearIs(int year)
        {
           _yearOfRelease = year;
        }
        
        [Given(@"plot is ""(.*)""")]
        public void GivenThePlotIs(string plot)
        {
           _plot = plot;
        }

        [Given(@"from list of actors ""(.*)"" are choosen")]
        public void GivenActorsAre(string actorsIndex)
        {
            _actors = actorsIndex;
        }

        [Given(@"from list of producers ""(.*)"" is choosen")]
        public void GivenTheProducerIs(string producerIndex)
        {
            _producer=producerIndex;
        }

        [Given(@"the following data is entered (.*), (.*), (.*), (.*), (.*)")]
        public void GivenTheFollowingDataIsEntered(string name,string plot,string actorsIndex,string producerIndex,string yearOfRelease)
        {
   
                _actors = actorsIndex;
                _producer =producerIndex;
                _yearOfRelease = int.Parse(yearOfRelease);
                _plot = plot;
                _name = name;
          
            
        }

        [When("movie is added to repository")]
        public void WhenTheMovieIsAdded()
        {
           
            try
            {
                _service.Add(_yearOfRelease, _name, _plot,_service.ChosenProducer(int.Parse(_producer)),_service.ChosenActors(_actors));
                _message = "movie is added successfully";
            }
            catch(ArgumentException ex)
            {
                _exception = ex;
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }
        [Then(@"the message ""(.*)"" display")]
        public void ThenTheMessageDisplay(string message)
        {
            Assert.Equal(message, _message);
        }



        [Then(@"an error (.*) is displayed")]
        public void ThenTheErrorIs(string message)
            {
                Assert.Equal(_exception.Message ,message);
            }


        [When(@"list of movies is fetched")]
        public void WhenListOfMoviesIsFetched()
        {
            try
            {
                _movies = _service.Get();
            }
            catch(Exception ex) 
            {
                _exception= ex; 
            }
        }

        [Then(@"output should be ""(.*)""")]
        public void ThenOutputShouldBe(string message)
        {
            Assert.Equal( _exception.Message, message);
        }


        [Then(@"the following movies must be displayed")]
        public void ThenTheFollowingMoviesMustBeListed(string message)
        {
            Assert.Equal(_message, message);
        }
        [When(@"list of movies is dislayed")]
        public void WhenListOfMoviesIsDislayed()
        {
            _message=_service.ListMovies();
        }


        [Then(@"the following movies must be listed")]
        public void ThenTheFollowingMoviesMustBeListed(Table table)
        {
            table.CompareToSet<Movie>(_movies);
        }


        [BeforeScenario("listRepository")]
        public void AddSampleMovie()
        {
            _service.Add(2019, "Ford v Ferrari", "American car designer Carroll Shelby and driver Ken Miles battle corporate interference", new Person("James Mangold", DateOnly.Parse("12-11-2000")), new List<Person>() { new Person("Matt Damon", DateOnly.Parse("12-11-2000")), new Person("Christian Bale", DateOnly.Parse("12-11-2000")) });
        }
        [BeforeScenario("displayRepository")]
        public void AddSampleMovieToDisplay()
        {
            _service.Add(2019, "Ford v Ferrari", "American car designer Carroll Shelby and driver Ken Miles battle corporate interference, the laws of physics and their own personal demons to build a revolutionary race car for Ford and challenge Ferrari at the 24 Hours of Le Mans in 1966.", new Person("James Mangold", DateOnly.Parse("12-11-2000")), new List<Person>() { new Person("Matt Damon", DateOnly.Parse("12-11-2000")), new Person("Christian Bale", DateOnly.Parse("12-11-2000")) });
        }
        [BeforeScenario("addMovie")]
        public void AddSampleActorAndProducer()
        {
            _service.AddActorOrProducer("brad", DateOnly.Parse("12-12-2012"), true);
            _service.AddActorOrProducer("daniel", DateOnly.Parse("12-12-2012"), true);
            _service.AddActorOrProducer("james", DateOnly.Parse("12-12-2012"), false);
        }
    }
}