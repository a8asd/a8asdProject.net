Feature: BookRide
	In order to book a ride from a to b
	As a Pat 
	I want to Charlie to be available

@mytag
Scenario: Pat books a ride with Charlie
	Given Pat is a registered customer
	And Charlie is a available driver
	When Pat books a ride
	Then Charlie is Pat's driver
