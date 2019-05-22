Feature: PayForRide

Background: There exists a booking 
Given Pat is a registered customer
And Charlie is an available driver
When Pat books a ride with Charlie

Scenario: Pat pays for a ride
	Given Pat has traveled 10 miles with Charlie
	And the rate is £2.00 per mile
	When Pat pays for the ride
	Then these invoices are in the system
	| Payee | Driver  | Distance | Amount |
	| Pat   | Charlie | 10.0     | 20.00  |
