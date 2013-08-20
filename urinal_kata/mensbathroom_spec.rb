require './mens_bathroom'

describe MensBathroom do

  describe "#pick_urinal" do

    context "Rule 1: Get as far away from the door as possible" do
      let(:game) { MensBathroom.new(5) }

      it 'picks the last urinal' do
          game.pick_urinal.should == 4
      end

      it 'picks the last available urinal' do
        game.occupy(4)
        game.pick_urinal.should == 3
      end
    end

    context "Rule 2: Never stand next to another dude" do

    end
     
    context "Rule 2, Exception 1: There is a line at the door" do
    
    end
     
    context "Rule 2, Exception 2: Someone else has already broken Rule 2" do

    end
     
    context "Rule 3: Never stand next to two other dudes" do

    end

  end

end


