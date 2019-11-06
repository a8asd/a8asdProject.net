Feature: BookingRides
	As Riley I want to be able to book rides
	So I can get from a to b quickly
	rule: rider only sees up to the 5 closest drivers

Background:
	Given the following riders
		| name  | latitude   | longitude  |
		| Riley | 51.6731459 | -0.9283008 |
		| Rory  | 1          | 1          |
	Given we have these drivers
		| name  | lat        | lng        |
		| Jamie | 51.6782551 | -1.9330204 |
		| Danny | 51.6782551 | -0.9330204 |
		| Fred  | 51.6782551 | -0.9330204 |
		| Frank | 51.6782551 | -0.9330204 |
		| Steve | 51.6782551 | -0.9330204 |

Scenario: Riley sees the ride option list
	When Riley requests a ride to 51.6782551,-1.9330204
	Then Riley sees these drivers
		| drivername | price |
		| Danny      | 12.00 |
		| Fred       | 12.00 |
		| Frank      | 12.00 |
		| Steve      | 12.00 |

Scenario: Danny accepts a ride
	When Riley requests a ride to 51.6782551,-1.9330204
	And Rory requests a ride to 53.6782551,-1.9366421
	And Danny accepts Riley's ride
	Then Riley's ride is accepted
	And Danny is busy
	And these requests are available
		| riderName | startLatitude | startLongitude | distance |
		| Rory      | 1             | 1              | 5855.429 |
