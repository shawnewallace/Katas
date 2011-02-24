Feature:  Bowling Game Scoring

  So that I can see my score
  As a Bowler playing a game
  I want to have my game scored

  Scenario: 0 Rolls
    Given I make no rolls
    When I score it
    Then My score should be 0

  Scenario: 1 roll
    Given I make the following rolls:
      | roll |
      | 2    |
    When I score it
    Then My score should be 2

  Scenario:  2 rolls
    Given I make the following rolls:
      | roll |
      | 6    |
      | 3    |
    When I score it
    Then My score should be 9

  Scenario:  with no spares or strikes
    Given I make the following rolls:
      | roll |
      | 1    |
      | 4    |
      | 4    |
      | 5    |
    When I score it
    Then My score should be 14

  Scenario:  with spares and strikes
    Given I make the following rolls:
      | roll |
      | 1    |
      | 4    |
      | 4    |
      | 5    |
      | 6    | 
      | 4    |
      | 5    |
      | 5    |
      | 10   |
      | 0    |
      | 1    |
      | 7    |
      | 3    |
      | 6    |
      | 4    |
      | 10   |
      | 2    |
      | 8    |
      | 6    |
    When I score it
    Then My score should be 133

  Scenario:  a perfect game
    Given I make the following rolls:
      | roll |
      | 10   |
      | 10   |
      | 10   |
      | 10   |
      | 10   |
      | 10   |
      | 10   |
      | 10   |
      | 10   |
      | 10   |
      | 10   |
      | 10   |
    When I score it
    Then My score should be 300
