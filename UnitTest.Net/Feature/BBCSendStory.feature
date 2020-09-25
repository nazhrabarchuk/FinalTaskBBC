Feature: BBCSendStory

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
	 | Lorem ipsum | Test | test@test.test |               | 4 Privet Drive, Little Whinging, Surrey |
	 And i check logIn checkbox field 
	 And click Submit
	 Then the story is not sent

@negative
Scenario: Send the coronovirus story with empty fields
	 When fill in the information on the bottom
	 | Story | Name | EmailAddress | ContactNumber | Location |
	 |       |      |              |               |          |
	 And click Submit
	 Then the story is not sent

@negative
Scenario: Send the coronovirus story with invalid email
	 When fill in the information on the bottom
	 | Story         | Name | EmailAddress | ContactNumber | Location |
	 | Another story | Name | email        | 111           | Location |
	 And click Submit
	 Then the story is not sent