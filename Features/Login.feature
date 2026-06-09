@ui @login
Feature: Login Functionality
  As a user
  I want to login to the application
  So that I can access protected features

  Background:
    Given I am on the login page

  @smoke @positive @critical
  Scenario: Successful login with valid credentials
    When I enter username "student"
    And I enter password "Password123"
    And I click the login button
    Then I should see the success message

  @negative @critical
  Scenario: Failed login with invalid credentials
    When I enter username "student"
    And I enter password "WrongPassword"
    And I click the login button
    Then I should see an error message

  @negative
  Scenario: Failed login with empty username
    When I enter password "Password123"
    And I click the login button
    Then I should see an error message