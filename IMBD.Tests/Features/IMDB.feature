Feature: IMDB Console app 
A console app similar to IMDB


@addMovieSuccess
Scenario: Add a movie to repository
	Given the movie has name "Ford and Ferrari"
	And the year of release is "2019"
	And plot is "American car designer Carroll Shelby and driver Ken Miles battle corporate interference"
	And from list of actors "1 2" are choosen
	And from list of producers "1" is choosen
	When movie is added to repository
	Then the message "movie is added successfully" display
	

@addMovie
Scenario Outline: Data entered is invalid
	Given the following data is entered <Name>, <Plot>, <Actors>, <Producer>, <Year>
	When movie is added to repository
	Then an error "Invalid data" is displayed
	Examples:
		| Name             | Plot                                                                                    | Actors		  | Producer     | Year |
		| 				   | American car designer Carroll Shelby and driver Ken Miles battle corporate interference | 1 2 		      | 1			 | 2019 |
		| Ford v Ferrari   | American car designer Carroll Shelby and driver Ken Miles battle corporate interference | 1 2			  | 1			 | 201  |
		| Ford v Ferrari   |																						 | 1 2			  | 1			 | 2019 |
		| Ford v Ferrari   | American car designer Carroll Shelby and driver Ken Miles battle corporate interference | 5 6			  | 1		 	 | 2019 |
		| Ford v Ferrari   | American car designer Carroll Shelby and driver Ken Miles battle corporate interference | 1 2			  | 4			 | 2019 |
	

@listEmptyRepository
Scenario: Movie repository should not be empty
	Given list of movies is fetched
	When repository is empty
	Then output should be "Currently repository is empty"


@listRepository
Scenario: List all movies in the repository
	Given list of movies is fetched
	When repository of movies is not empty
	Then the following movies must be listed
	"""
	Ford v Ferrari (2019)
	Plot - American car designer Carroll Shelby and driver Ken Miles battle corporate interference, the laws of physics and their own personal demons to build a revolutionary race car for Ford and challenge Ferrari at the 24 Hours of Le Mans in 1966.
	Actors - Matt Damon, Christian Bale
	Producers - James Mangold
	"""