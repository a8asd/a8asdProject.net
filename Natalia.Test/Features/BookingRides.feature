Feature: BookingRides
	As Riley I want to be able to book a ride

Scenario: Riley sees a list of available drivers
	Given Riley is a member
	And Danny is a driver at 50.000, 1.000
	When Riley requests a ride from 51.000, 2.000
	Then Riley sees this list of drivers
	| name  |
	| Danny |