Feature: BookRide
So I can get from A to B
as a customer
I want to be able to book a ride

Scenario: view available drivers
	Given George is a customer at 51.44931, -2.601203
	And these drivers 
	| name    | latitude   | longitude  |
	| Craig   | 51.4590176 | -2.5926543 |
	| Richard | 51.476366  | -2.6290553 |
	When Charlie asks for the available drivers list
	Then these drivers are displayed
		| Name    | time to pickup |
		| Craig   | 1m 12s         |
		| Richard | 3m 29s         |