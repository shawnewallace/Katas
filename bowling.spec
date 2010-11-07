require 'rubygems'
gem 'rspec'
require 'bowling'

describe Game do
  it "score be 0 with 0 rolls" do
    game = Game.new
    game.score().should == 0
  end
  
  it "should have 10 frames" do
    game = Game.new
    game.frames.size.should == 10
  end
  
end

describe Roll do
  
  (1..10).to_a.each do |roll|
    it "should be valid if #{roll}" do
      roll = Roll.new(roll)
      roll.valid?.should == true
    end
  end
  
  [
    -1, 11, 12, 13, 14, 100, 500
    ].each do |roll|
      it "should be invalid if #{roll}" do
        roll = Roll.new(roll)
        roll.valid?.should == false
      end
  end
  
end

describe Frame do
  
  it "should have 1 to 3 rolls"
  
  it "should have a maximum score of 10 if not final frame"
    
  it "should have a maximum score of 20 if final frame"
  
  it "final should be false be default" do
    frame = Frame.new
    frame.final?.should be_false
  end
  
end