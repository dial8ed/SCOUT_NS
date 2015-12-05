Feature: MaterialAdjustments
	In order to reflect actual inventory quantities
	As a materials manager
	I want to adjust material in to and out of the system

@mytag
Scenario: Adjust material into inventory where item does not exist
	Given I have input a valid Part Number 
		And Input Source Type, Locations, and Comments
		When I click Adjust	
		Then The Inventory Item should be created 
			And The Inventory Qty should by the adjustment qty plus the starting qty

@mytag
Scenario: Adjust material into inventory where item does exist
	Given I have input a valid Part Number 
		And Input Source Type, Locations, and Comments
		When I click Adjust	
		Then The Inventory Qty should by the adjustment qty plus the starting qty

@myTag
Scenario: Adjust material out of inventory where item does not exist
	Given I have input a valid Part Number
		And Input Source Type, Locations, and Comments
		When I click Adjust
		Then The I should see an error stating that the inventory item does not exist

@myTag
Scenario: Adjust material out of inventory where item does exist
	Given I have input a valid Part Number
		And Input Source Type, Locations, and Comments
		When I Click Adjust
		Then The Inventory Qty should be the adjustment qty minus the starting qty

@myTag
Scenario: Adjust material in or out where Part Number is invalid
	Given I have input a invalid Part Number
	When I Click Adjust
	Then I Should see an error stating the Part Number is invalid
