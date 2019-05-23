Feature: ViewRideHistory
	When a driver has completed a ride they are able to view it in a completed list.

@mytag
Scenario: View Ride History
	Given Charlie is a registered driver
	And Pat is a registered customr
	And Pat has a booking with Charlie
	And Pat has completed a booking with Charlie travelling 10 miles
	When Charlie views the work history
	Then These are the rides for Charlie
	| Driver  | Customer |  Distance | 
	| Charlie | Pat      |  10       | 
