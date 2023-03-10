using IMDB;
using IMDB.Repository;
using IMDB.Service;
using IMDB.Domain;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using TechTalk.SpecFlow.Assist;

namespace IMDB.Tests.StepDefinitions

{
    [Binding]
    public sealed class IMDBStepDefinitions
    {
        private IIMDBService _service;
        private string _name, _plot;
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
        public void GivenTheFollowingDataIsEntered(string name,string plot,string actorsIndex,int producerIndex,int yearOfRelease)
        {
            _yearOfRelease=yearOfRelease;
            _plot=plot;
            _name=name;
            _producer = _service.ChosenProducer(producerIndex);
            _actors=_service.ChosenActors(actorsIndex);
        }

        [When("movie is added to repository")]
        public void WhenTheMovieIsAdded()
        {
            try
            {
                _service.Add(_yearOfRelease, _name, _plot, _producer, _actors);
            }
            catch (Exception ex)
            {
                _exception = ex;
            }
        }

        [Then(@"an error ""(.*)"" is displayed")]
        public void ThenTheErrorIs(string message)
            {
                Assert.Equal(message, _exception.Message);
            }


        [Given(@"list of movies is fetched")]
        public void WhenListOfMoviesIsFetched()
        {
            _movies = _service.Get();
        }

        [When(@"repository is empty")]
        public void GivenRepositoryIsEmpty()
        {
            if (_movies == null) 
            {
               
            }
        }
        [Then(@"output should be ""(.*)""")]
        public void ThenOutputShouldBe(string message)
        {
            Assert.Equal( "Currently repository is empty", message);
        }
        [When(@"repository of movies is not empty")]
        public void GivenRepositoryOfMoviesIsNotEmpty()
        {
           if ( _movies != null) { }
        }

        [Then(@"the following movies must be listed")]
        public void ThenTheFollowingMoviesMustBeListed(string message)
        {
            Assert.Equal(_service.ListMovies(), message);
        }
        [Then(@"the message ""(.*)"" display")]
        public void ThenMessageShown(string message)
        {
            Assert.Equal("movie is added successfully",message);
        }
    }
}