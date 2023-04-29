Feature: LoginSteps

@Sanity
Scenario Outline: Login with valid and invalid userNames
	Given Enter <userNames> 
	And Enter password
	When ClickSignInButton
	Then user should be logged

	Examples:
	| userNames						|
	| 'alberto.hirota@gmail.com'    |
	| 'alberto.invalid@gmail.com'   |

@Regression
Scenario Outline: PerformanceLogin
	Given Enter 'alberto.hirota@gmail.com' 
	And Enter password
	Then user performance login page should be less than 10 seconds
	And user should be logged

@Sanity @Regression
Scenario: Logout with valid user
	Given Enter 'alberto.hirota@gmail.com' 
	And Enter password
	When ClickSignInButton
	And logout
	Then user should be not logged

@Regression
Scenario: Checking Invalid user error
	Given Enter 'alberto.invalid@gmail.com' 
	Then Validate user error message
