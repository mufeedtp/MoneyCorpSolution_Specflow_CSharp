Feature: moneycorp
    create test   

@tag1
  Scenario: Verify article links
    Given MoneyCorp website opened
    When Select the region and language "USA English"
    Then verify the selected region is displayed
    And click on find out more for Foreign exchange Solutions
    Then verify Foreign exchange Solutions page arrived
    And Search "international payments"
    Then Verify search result page is arrived
    And click show more results until not available
    Then verify all articles has link starting with
