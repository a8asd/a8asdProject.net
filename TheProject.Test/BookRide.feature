Feature: BookRide
	So that I can get from a to b
	As Pat I can book a ride

@mytag
Scenario: Pat books a ride with Charlie
	Given Dave is a registered customer
	And Charlie is an available driver
	When Pat books a ride with Charlie
	Then Charlie is booked to Pat
