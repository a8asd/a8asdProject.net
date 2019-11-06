Feature: BookingRides
	As Riley I want to book rides so I can get from A to b quickly


Scenario: Riley sees the ride option list
	Given Riley is a member
	And Danny is a driver at 51.669326,-0.9120708
	When Riley requests  a ride from 51.6747904,-0.9132962
	Then Riley sees these drives
	| name  |
	| Danny |
