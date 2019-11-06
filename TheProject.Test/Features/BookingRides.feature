﻿Feature: BookingRides
	As Riley I want to be able to book rides
	So I can get from a to b quickly
	rule: rider only sees up to the 5 closest drivers
Background:
	Given the following riders
	| name  | latitude   | longitude  |
	| Riley | 51.6731459 | -0.9283008 |
	| Rory  | 1          | 1          |
	And we have these drivers
	| name  | lat        | lng |
	| Jamie | 51.6782551 |-1.9330204 |
	| Danny | 51.6782551 |-0.9330204 |
	| Fred	| 51.6782551 |-0.9330204 |
	| Frank | 51.6782551 |-0.9330204 |
	| Steve | 51.6782551 |-0.9330204 |


Scenario: Riley sees the ride option list
	When Riley requests a ride
	Then Riley sees these drivers
	| name  |
	| Danny |
	| Fred  |
	| Frank |
	| Steve |

#Scenario: Danny accepts a ride
#	And these rides are on offer
#	| distance | riderName | lat | long |
#	| 10       | Riley     | 0   | 0    |
#	| 16       | Rory      | 1   | 1    |
#	When Danny accepts Riley's ride
#	Then Riley's ride is accepted
#	And Danny is busy
#	And these rides are on offer
#	| distance | riderName | lat | long |
#	| 16       | Rory      | 1   | 1    |