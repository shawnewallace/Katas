require 'rubygems'
gem 'rspec'
require 'tennis_match'

describe TennisMatch do
  it "should have two scores initialized to 'love'" do
    match = TennisMatch.new()
    match.ScoreOne.should == 'love'
    match.ScoreTwo.should == 'love'
  end
  
  [
    [  0,    'love'],
    [  1, 'fifteen'],
    [  2,  'thirty'],
    [  3,   'forty'],
    [  4,   'forty'],
    [ 10,   'forty'],
    [100,   'forty']
  ].each do |numberOfScores, score|
    it "should have the score of #{score} with #{numberOfScores} score increment for player one" do
      result = (1..numberOfScores).map { |item| item }
      match = TennisMatch.new()
    
      result.each do
        match.PlayerOneScores()
      end
      
      match.ScoreOne.should == score
    end
  end
  
  [
    [  0,    'love'],
    [  1, 'fifteen'],
    [  2,  'thirty'],
    [  3,   'forty'],
    [  4,   'forty'],
    [ 10,   'forty'],
    [100,   'forty']
  ].each do |numberOfScores, score|
    it "should have the score of #{score} with #{numberOfScores} score increment for player two" do
      result = (1..numberOfScores).map { |item| item }
      match = TennisMatch.new()
    
      result.each do
        match.PlayerTwoScores()
      end
      
      match.ScoreTwo.should == score
    end
  end
  
  [
    [ 0,0,           "love-love"],[1, 0,        "fifteen-love"],[  2, 0,    "thirty-love"],
    [ 3,0,          "forty-love"],[0, 1,        "love-fifteen"],[  0, 2,    "love-thirty"],
    [ 0,3,          "love-forty"],[1, 1,     "fifteen-fifteen"],[  2, 2,  "thirty-thirty"],
    [ 3,3,               "deuce"],[4, 4,               "deuce"],[ 10,10,          "deuce"],
    [ 4,3,"advantage player one"],[3, 4,"advantage player two"],[  4, 0,"player one wins"],
    [ 4,2,     "player one wins"],[0, 4,     "player two wins"],[  2, 4,"player two wins"],
    [10,8,     "player one wins"],[8,10,     "player two wins"],[100, 0,"player one wins"]
  ].each do |playerOneWins, playerTwoWins, expectedScore|
    it "should have a score #{expectedScore} if player one scores #{playerOneWins} times and player two scores #{playerTwoWins} times" do
      match = TennisMatch.new()
      
      result = (1..playerOneWins).map { |item| item }
      result.each do
        match.PlayerOneScores()
      end
      
      result = (1..playerTwoWins).map { |item| item }
      result.each do
        match.PlayerTwoScores()
      end
      
      match.Score.should == expectedScore
    end
  end
end