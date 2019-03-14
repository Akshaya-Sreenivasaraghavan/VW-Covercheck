Feature: SpecFlowFeature1
	To check vehicle exists

@mytag
Scenario Outline: Check to see if a vehicle exists in the given site
	Given I have loaded the site 'https://covercheck.vwfsinsuranceportal.co.uk/' in browser
	When I enter the registration number <registrationNumber> in the text box
	And I also click find vehical button
	Then the result <message> should be displayed
	And the browser is closed
Examples: 
	| registrationNumber | message                |
	| OV12UYY            | result for             |
	| OV12Y              | sorry record not found |