Feature: Company
Company create and check test
    
    
Scenario: Create Company
    Given  the domain name is "www.majidalfuttaim.com"
    And  the company name is "Majid Al Futtaim Group"
    And the ecosystem id for company is 12156
    And the licence type is "ContinuousAnnual"
    When the company created
    Then company id will be returned
    
Scenario: Search the Company
    Given send the ecosystem id 12156
    And send the GenericSearchText is "Majid";
    When search the company
    Then api will be returned key
    
    
Scenario: Get the Company
    Given send the key 
    And get the company
    When verify scan status is "Extended Rescan Results Ready"
    Then verify Values