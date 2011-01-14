require 'rspec'
require 'bowling_game'

describe Game do
  
  before(:each) { @game = Game.new }

  it 'is 0 with 0 rolls' do
    @game.Score().should == 0
  end

  context 'with one roll' do
    before { @game.Roll(9) }
    
    it 'is returns the value rolled' do
       @game.Score().should == 9
    end
  end

  context 'with two rolls' do
    before {
      @game.Roll(6)
      @game.Roll(3)
    }

    it 'returns the sum of the values rolled' do
      @game.Score().should == 9
    end
  end

  context 'with multiple rolls' do

    context 'with no spares or strikes' do     
      before{
         @rolls = [1, 4, 4, 5]

        @rolls.each do |roll|
          @game.Roll(roll)
        end
      }

      it 'returns the correct score' do
        @game.Score().should == 14
      end
    end

    context 'with spares and strikes'do
      before {
        @rolls = [1, 4, 4, 5, 6, 4, 5, 5, 10, 0, 1, 7, 3, 6, 4, 10, 2, 8, 6]
        
        @rolls.each do |roll|
          @game.Roll(roll)
        end
      }

       it 'returns the correct score' do
        @game.Score().should == 133
      end
    end

    context 'perfect game should be 300' do
       before {
        @rolls = [10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10]
        
        @rolls.each do |roll|
          @game.Roll(roll)
        end
      }

       it 'is 300' do
        @game.Score().should == 300
      end

    end
  end

end
