Feature:  Bowling Game Scoring

	So that I can see my score
	As a Bowler playing a game
	I want to have my game scored

	Description: 
	The game consists of 10 frames.  In each frame the player has
	two opportunities to knock down 10 pins.  The score for the frame is the total
	number of pins knocked down, plus bonuses for strikes and spares.

	A spare is when the player knocks down all 10 pins in two tries.  The bonus for
	that frame is the number of pins knocked down by the next roll.  So in frame 3
	above, the score is 10 (the total number knocked down) plus a bonus of 5 (the
	number of pins knocked down on the next roll.)

	A strike is when the player knocks down all 10 pins on his first try.  The bonus
	for that frame is the value of the next two balls rolled.

	In the tenth frame a player who rolls a spare or strike is allowed to roll the extra
	balls to complete the frame.  However no more than three balls can be rolled in
	tenth frame.

	Scenario: 0 Rolls
		Given A new game
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

	Scenario:  another perfect game
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

	

	
