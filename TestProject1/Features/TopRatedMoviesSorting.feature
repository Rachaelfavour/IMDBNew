Feature: TopRatedMoviesSorting
As a user when I load “Top related Movies” page when I sort the page “Release Date” 
then I should see the list of movies should be displayed in order of release date

Scenario: Sort by Release date
Given I am on the Top rated Movies page
When I sort by "Release Date"
Then I should see the list of movies should be displayed in order of release date