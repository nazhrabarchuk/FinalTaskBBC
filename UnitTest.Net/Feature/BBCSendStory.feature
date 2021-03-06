﻿Feature: BBCSendStory

 Background: 
	Given the BBC Home page is open
	And I go to News
	And click on Coronavirus tab
	And click on Your Coronavirus Stories tab
	And go to “How to share with BBC news”
	

@negative
Scenario: Send the coronovirus story
	 When fill in the information on the bottom
	 | Story       | Name | EmailAddress   | ContactNumber | Location                                |
	 | Lorem ipsum |      | test@test.test | 111           | 4 Privet Drive, Little Whinging, Surrey |
	 And i click checkbox input in the form
	 And click Submit
	 Then the error message is exist 

@negative
Scenario: Send the coronovirus story with empty fields
	 When fill in the information on the bottom
	 | Story | Name | EmailAddress | ContactNumber | Location |
	 |       |      |              |               |          |
	 And click Submit
	 Then the error message is exist 

@negative
Scenario: Send the coronovirus story with invalid email
	 When fill in the information on the bottom
	 | Story         | Name | EmailAddress | ContactNumber | Location |
	 | Another story | Name | email        | 111           | Location |
	 And i click checkbox input in the form 
	 And click Submit
	 Then the error message is exist 