Feature: Auden Loan APP
	As a user i should be able to apply for loan.

	Background: 
	Given I am on Auden website


Scenario: Auden Loan Booking App
	Then I should see home link
	
	And I scroll the slider bar to home and end
	Then I should see the coresponding amount on the page

	When I scroll the slider bar to the last monthly instalments
    Then I should see the corresponding instalment period  

                                                              
    And I click on the repayment calendar button                          
    And I scroll to view the calendar
	
    And I select a repayment weekend date form the calendar               
    Then I should see a previous working date as default                  
                                                                      
    And  I close the browser                                              
                                                                      

