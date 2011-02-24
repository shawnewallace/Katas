Feature:  Bowling Game Scoring

	So that I can see my score
	As a Bowler playing a game
	I want to have my game scored

	Scenario: 0 Rolls
		Given A new game
		When I make no rolls
		Then My score should be 0

	Scenario: 1 roll
		Given A new game
		When I make the following rolls: 2
		Then My score should be 2

	Scenario:  2 rolls
		Given A new game
		When I make the following rolls: 6, 3
		Then My score should be 9

	Scenario:  with no spares or strikes
		Given A new game
		When I make the following rolls: 1, 4, 4, 5
		Then My score should be 14

	Scenario:  a perfect game
		Given A new game
		When I make the following rolls: 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10
		Then My score should be 300

	Scenario:  with spares and strikes
		Given A new game
		When I make the following rolls:
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
		Then My score should be 133

	Scenario:  aother perfect game
		Given A new game
		When I make the following rolls:
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
		Then My score should be 300

	
