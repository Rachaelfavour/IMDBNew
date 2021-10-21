Feature: TopRatedMovies
As a user when I load “Top related Movies” page when I search for Genre as “Comedy” 
then I should see list of movies that should only contain relevant results 

Scenario: search for Genre as Comedy
Given I am on the Top rated Movies page
When I search for Genre as "Comedy"
Then I should see list of movies that should only contain "comedy", "comedia" or "comedic"