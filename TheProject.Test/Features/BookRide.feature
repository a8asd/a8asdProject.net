Feature: BookRide
So I can get from A to B
as a customer
I want to be able to book a ride

available drivers shows drivers that are less than 30 minutes or less away
Scenario: view available drivers
	Given George is a customer at 51.44931, -2.601203
	And these drivers are available
		| name    | latitude   | longitude  |
		| Richard | 51.476366  | -2.6290553 |
		| Sam     | 51.8596987 | -2.1842129 |
		| Craig   | 51.4590176 | -2.5926543 |
		| Seb     | 51.5576583 | -1.8115952 |
	When Charlie asks for the available drivers list
	Then these drivers are displayed
		| Name    | time to pickup |
		| Craig   | 1m 12s         |
		| Richard | 3m 29s         |