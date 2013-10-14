Feature: AddATodoItem
	In order to get stuff done
	As an authenticated user
	I want to add todo items

Scenario: Adding a blank todo Item
	Given I write  into the application
	When I add the TodoItem
	Then the result should be 0 todo items

Scenario: Adding a valid todo Item
	Given I write Call mom tomorrow into the application
	When I add the TodoItem
	Then the result should be 1 todo items

Scenario: Adding a valid todo Item on a holiday
	Given I write Call mom tomorrow into the application
	And It is a Holiday
	When I add the TodoItem
	Then the result should be 0 todo items

