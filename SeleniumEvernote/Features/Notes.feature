Feature: NotesSteps

@Sanity
Scenario: Write a new note
	Given Enter 'alberto.hirota@gmail.com' 
	And Enter password
	When ClickSignInButton
	And Click new Note
	And Write a note 'Video Slots1'
	And logout
	Then user should be not logged

@Regression
Scenario: Verify note was created
	Given Enter 'alberto.hirota@gmail.com' 
	And Enter password
	When ClickSignInButton
	And Click new Note
	And Write a note 'Video Slots2'
	Then Validate notes exists 'Video Slots2'

@Regression
Scenario: Write a new note, log out and validate it exists
	Given Enter 'alberto.hirota@gmail.com' 
	And Enter password
	When ClickSignInButton
	And Click new Note
	And Write a note 'Video Slots3'
	And logout
	And Login again 'alberto.hirota@gmail.com'
	Then Validate notes exists 'Video Slots3'