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
        private List<string> _actors;
        private string _producer;
        private Exception _exception;
        private List<Movie> _movies;

        public IMDBStepDefinitions()
        {
            _service = new IMDBService();
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
            _actors = _service.ChosenActors(actorsIndex);
        }

        [Given(@"from list of producers ""(.*)"" is choosen")]
        public void GivenTheProducerIs(int producerIndex)
        {
            _producer=_service.ChosenProducer(producerIndex);
        }

        [Given(@"the following data is entered (.*), (.*), (.*), (.*), (.*)")]
        public void GivenTheFollowingDataIsEntered(string name,string plot,string actorsIndex,string producerIndex,string yearOfRelease)
        {
            
            _actors = _service.ChosenActors(actorsIndex);
            _producer = _service.ChosenProducer(int.Parse(producerIndex));
            _yearOfRelease = int.Parse(yearOfRelease);
            _plot=plot;
            _name=name;
          
            
        }

        [When("movie is added to repository")]
        public void WhenTheMovieIsAdded()
        {
            try
            {
                _service.Add(_yearOfRelease, _name, _plot, _producer, _actors);
                _message = "movie is added successfully";
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"an error ""(.*)"" is displayed")]
        public void ThenTheErrorIs(string message)
            {
                Assert.Equal(_exception.Message ,message);
            }


        [Given(@"list of movies is fetched")]
        public void WhenListOfMoviesIsFetched()
        {
            _movies = _service.Get();
        }

        [When(@"repository is empty")]
        public void GivenRepositoryIsEmpty()
        {
            if (_movies.Count() == 0) 
            {
                _message="Currently repository is empty";
            }
        }
        [Then(@"output should be ""(.*)""")]
        public void ThenOutputShouldBe(string message)
        {
            Assert.Equal( _message, message);
        }
        [When(@"repository of movies is not empty")]
        public void GivenRepositoryOfMoviesIsNotEmpty()
        {
           if ( _movies.Count() > 0) 
            {
                _message=_service.ListMovies();
            }
        }

        [Then(@"the following movies must be listed")]
        public void ThenTheFollowingMoviesMustBeListed(string message)
        {
            Assert.Equal(_message, message);
        }
        [Then(@"the message ""(.*)"" display")]
        public void ThenMessageShown(string message)
        {
            Assert.Equal(_message,message);
        }
        [BeforeScenario("listRepository")]
        public void AddSampleMovieToPrint()
        {
            _service.Add(2019, "Ford and Ferrari", "American car designer Carroll Shelby and driver Ken Miles battle corporate interference", "James Mangold",new List<string>() { "Matt Damon", "Christian Bale" });
        }
    }
}