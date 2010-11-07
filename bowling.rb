class Game
  
  attr_accessor :frames
  
  def initialize()
    @frames = Array.new(10)
  end
  
  def roll(pins)
  end
  
  def score()
    0
  end
end

class Frame
  
  def initialize()
    @final = false;
  end
  
  def final?()
    @final
  end
  
end

class Roll
  def initialize(value)
    @value = value
  end
  
  def valid?()
    return true if @value >= 0 and @value <=10
    false
  end
end