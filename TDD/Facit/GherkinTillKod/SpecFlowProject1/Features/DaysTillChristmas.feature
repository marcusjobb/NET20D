Feature: DaysTillChristmas
	The user loves christmas and wants to know the amount of days till Christmas

@Christmas
Scenario: Get the amount of days till Christmas
	Given the date is june 20
	When asking for the amount of days
	Then the result should more than 0

@Christmas
Scenario: Get exact the amount of days till Christmas
	Given the date is june 20
	When asking for the amount of days
	Then the result should be 187
