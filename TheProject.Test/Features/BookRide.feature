Feature: BookRide
So that I can get from a to b
As Pat
I want to book a ride

Background:
	Given Pat is a registered customer
	Given Dave is a registered customer
	Given Charlie is an available driver
	Given Kevin is an available driver
	Given Ben is an available driver

Scenario: Pat books a ride with Charlie
	When Pat books a ride with Charlie
	And Dave books a ride with Ben
	Then these are the bookings
	| DriverName | CustomerName |
	| Charlie    | Pat          |
	| Ben        | Dave         |

Scenario: Pat requests offers
When Pat requests offers
Then these are the offers
| Driver  | Distance |
| Charlie | 10       |
| Kevin   | 25       |



