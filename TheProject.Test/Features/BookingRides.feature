Feature: BookingRides
	As Riley I want to be able to book rides
	So I can get from a to b quickly

	rule: rider only sees up to the 5 closest drivers

Scenario: Riley sees the ride option list
	Given Riley is a member 
	And Danny is a driver at 51.6782551,-0.9330204
	When Riley requests a ride from 51.6731459,-0.9283008
	Then Riley sees these drivers
	| name  |
	| Danny |