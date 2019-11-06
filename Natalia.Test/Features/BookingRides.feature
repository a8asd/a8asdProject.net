Feature: BookingRides
	As Riley I want to be able to book a ride

Scenario: Riley sees a list of available drivers
	Given Riley is a member
	And Danny is a driver at 50.000, 1.000
	When Riley requests a ride from 51.000, 2.000
	Then Riley sees this list of drivers
	| name  |
	| Danny |

Scenario: Danny accepts a ride
	Given Danny is a driver
	And these rides are on offer
	| distance | riderName | lat | long |
	| 10       | Riley     | 0   | 0    |
	| 16       | Rory      | 1   | 1    |
	When Danny accepts Riley's ride
	Then Riley's ride is accepted
	And Danny is busy
	And these rides are on offer
	| distance | riderName | lat | long |
	| 16       | Rory      | 1   | 1    |