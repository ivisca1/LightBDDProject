Feature: User Login

@tag1
Scenario: Successful login
	Given the user is already registered
	When the user submits valid login credentials
	Then the system should return a successful login response

@tag2
Scenario: Failed login due to invalid credentials
	Given the user is already registered
	When the user submits incorrect login credentials
	Then the system should return an unauthorized response
