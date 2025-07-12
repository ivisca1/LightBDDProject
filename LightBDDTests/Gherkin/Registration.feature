Feature: Registration

@tag1
Scenario: Successful registration
	Given the user is not registered
	When the user submits a valid email and password
	Then the system should create a new user and return a success response

@tag2
Scenario: Registration with existing email
	Given the user is already registered
	When the user submits the same email and password again
	Then the system should return a conflict or error response
