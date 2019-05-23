Feature: PayForRide

Background: There exists a booking 
Given Pat is a registered customer
And Charlie is an available driver
When Pat books a ride with Charlie

Scenario: Customer pays for a ride with Driver
	Given These rides have occurred
	| Customer | Driver  | Distance |
	| Tom      | Sally   | 5.5      |
	| Pat      | Charlie | 10.0     |
	And theses rates exist
	| Distance | Rate |
	| 5        | 3    |
	| 10       | 2    |
	| 20       | 1    |
	When Pat pays for a ride with Charlie
	Then these invoices are in the system
	| Payee | Driver  | Distance | Amount |
	| Pat   | Charlie | 10.0     | 20.00  |
