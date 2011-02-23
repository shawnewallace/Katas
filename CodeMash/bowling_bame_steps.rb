require 'bowling_game'


Before do
  @game = Game.new
  @score = 0
end

Given /^I make no rolls$/ do
end

When /^I score it$/ do
  @score = @game.Score
end

Then /^My score should be (\d+)$/ do |expected|
  @score.should eq(Integer(expected))
end

Given /^I make the following rolls:$/ do |table|
  table.hashes.each {|roll| @game.Roll(Integer(roll[:roll]))}
end

