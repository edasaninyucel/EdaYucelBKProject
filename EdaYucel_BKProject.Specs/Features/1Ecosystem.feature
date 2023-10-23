Feature: Ecosystem
Create an Ecosystem and Verify if it created

Scenario: Create Ecosystem
    Given the ecosystem name is "Healthcare Industry"
    When  the ecosystem created
    Then ecosystem id will be returned
    
Scenario:  Verify Ecosystem
    Given the ecosystem id
    When the ecosystem verified
    Then status code will success

