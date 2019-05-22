Feature: BookRide
So that I can get from a to b
As Pat
I want to book a ride

Scenario: Pat books a ride with Charlie
	Given Pat is a registered customer
	And Dave is a registered customer
	And Charlie is an available driver
	And Ben is an available driver
	When Pat books a ride with Charlie
	And Dave books a ride with Ben
	Then these are the bookings
	| DriverName | CustomerName |
	| Charlie    | Pat          |
	| Ben        | Dave         |



