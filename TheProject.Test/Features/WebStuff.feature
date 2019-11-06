@webstuff
Feature: BookingRidesWeb
	As Riley I want to be able to book rides on the web
	So I can get from a to b quickly 

	rule: rider only sees up to the 5 closest drivers

#Background:
#	Given the following riders
#	| name  | latitude   | longitude  |
#	| Riley | 51.6731459 | -0.9283008 |
#	| Rory  | 51.5731459 | -0.8283008 |
#	Given we have these drivers
#	| name  | lat        | lng |
#	| Jamie | 51.6782551 |-1.9330204 |
#	| Danny | 51.6782551 |-0.9330204 |
#	| Fred	| 51.6782551 |-0.9330204 |
#	| Frank | 51.6782551 |-0.9330204 |
#	| Steve | 51.6782551 |-0.9330204 |
#
#@webstuff
#Scenario: Riley sees the ride option list
#	When Riley requests a ride
#	Then Riley sees these drivers
#	| name  |
#	| Danny |
#	| Fred  |
#	| Frank |
#	| Steve |