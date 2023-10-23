Feature: Delete
Delete company and ecosystem
    
    
Scenario: Delete Company
    Given  the company id is 91184
    And the company deleted
    When get the company
    Then status code will not be success
    
Scenario: Delete Ecosystem
    Given the ecosystem id is 12156
    Then the ecosystem deleted 
    
    
  