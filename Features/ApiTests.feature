@api @smoke
Feature: REST API Tests
  As a QA Engineer
  I want to test REST API endpoints
  So that I can verify API functionality

  @positive
  Scenario: Get post by ID
    When I send a GET request to "/posts/1"
    Then the response status code should be 200
    And the response should contain a title

  @positive
  Scenario: Create a new post
    When I send a POST request to "/posts" with body:
      | userId | 1          |
      | title  | Test Post  |
      | body   | Test Body  |
    Then the response status code should be 201

  @negative
  Scenario: Get non-existent post
    When I send a GET request to "/posts/99999"
    Then the response status code should be 200