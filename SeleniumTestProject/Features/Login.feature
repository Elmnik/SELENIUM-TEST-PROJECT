Feature: Login functionality

  Scenario: Successful login with valid credentials
    Given I open the login page
    When I enter valid credentials
    And I submit the login form
    Then I should be redirected to the dashboard

  Scenario: Unsuccessful login with invalid credentials
    Given I open the login page
    When I enter invalid credentials
    And I submit the login form
    Then I should see an error message

  Scenario: Blank username or password
    Given I open the login page
    When I submit the login form without entering any credentials
    Then I should see a message indicating that fields are required