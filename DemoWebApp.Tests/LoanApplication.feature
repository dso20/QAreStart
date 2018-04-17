Feature: LoanApplication

Scenario: Loan is application is submitted and completed
	Given  I navigate to Loan page
	And I fill in firstname Nick
	And I fill in surname Grant
	And I select have loan
	And I accept terms conditions
	When I submit form
	 Then I go to the loan completed page displaying my name Nick

Scenario: Loan application is submitted without accepting terms
	 Given I navigate to Loan page
	 And I fill in firstname David
	 And I fill in surname Owen
	 And I select have loan
	 When I submit form
	Then I get terms error message You must accept the terms and conditions

