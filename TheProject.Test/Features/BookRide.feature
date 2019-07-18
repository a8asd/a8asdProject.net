Feature: BookRide
So I can get from A to B
as a customer
I want to be able to book a ride

Scenario: view available drivers
	Given George is a customer at 51.44931, -2.601203
	And Craig is a driver at 51.4590176, -2.5926543
	And Richard is a driver at 51.476366, -2.6290553
	When Charlie asks for the available drivers list
	Then these drivers are displayed
		| Name    | time to pickup |
		| Craig   | 1              |
		| Richard | 3              |

