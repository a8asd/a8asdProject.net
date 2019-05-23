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
And Charlie is available 10 miles away
And Kevin is available 25 miles away
Then these are the offers
| Driver  | Distance |
| Charlie | 10       |
| Kevin   | 25       |

Scenario: Pat accepts an offer
When Charlie is available 10 miles away
And Kevin is available 25 miles away
And Pat accepts the offer from Kevin
Then these are the bookings
| DriverName | CustomerName |
| Kevin    | Pat          |



