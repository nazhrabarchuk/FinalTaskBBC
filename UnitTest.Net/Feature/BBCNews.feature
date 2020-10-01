Feature: BBCNewsSteps

@smoke
Scenario: The headline article name is correct
	Given the BBC Home page is open
	When I go to News page
	Then the headline article name loaded succesfully

@smoke
Scenario: The secondary articles name is correct
	Given the BBC Home page is open
	When I go to News page
	Then the seconady articles name loaded succesfully 

@smoke 
Scenario: Search by copied headline article name
	Given the BBC Home page is open
	When I go to News page
	And i put copied name to search input
	And i click search
	Then the title of the first article is equal to the searched value
