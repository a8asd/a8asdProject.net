Feature: ViewRideHistory
	When a driver has completed a ride they are able to view it in a completed list.

@mytag
Scenario: View Ride History
	Given Charlie is a registered driver
	And Charlies has completed a ride with Pat
	When Charlie views the work history
	Then These are the rides
	| Driver  | Customer | Date        | Distance | Rate |
	| Charlie | Pat      | 01-Jan-2019 | 10       | 2    |
