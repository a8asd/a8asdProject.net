Feature: BookingRides
	As Riley I want to be able to book rides
	So I can get from a to b quickly

	rule: rider only sees up to the 5 closest drivers

Scenario: Riley sees the ride option list
	Given Riley is a member at 51.6731459,-0.9283008
	And we have these drivers
	| name  | lat        | lng |
	| Jamie | 51.6782551 |-1.9330204 |
	| Danny | 51.6782551 |-0.9330204 |
	| Fred	| 51.6782551 |-0.9330204 |
	| Frank | 51.6782551 |-0.9330204 |
	| Steve | 51.6782551 |-0.9330204 |
	When Riley requests a ride
	Then Riley sees these drivers
	| name  |
	| Danny |
	| Fred  |
	| Frank |
	| Steve |