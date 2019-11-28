
Feature: BookRide

Scenario: Fred sends a request to MyTaxi
	Given these operators
		| name      |
		| MyTaxi    |
		| SuperTaxi |
	And these clients
		| name  |
		| Fred  |
		| Peter |
	When Fred Sends a request to MyTaxi
	When Peter Sends a request to SuperTaxi
	Then these requests exist
		| client | operator  |
		| Fred   | MyTaxi    |
		| Peter  | SuperTaxi |
