class Game

  def initialize()
    @rolls = []
  end

  def Score
    (1..10).inject(0) { |score, frame| score += score_for frame }
  end

  def Roll(pins)
    @rolls << pins
    @rolls << 0 if first_throw_is_strike?
  end

  def score_for(frame)
    return strike_score_for frame if is_strike_at? frame
    return spare_score_for frame if is_spare_at? frame
    open_score_for frame
  end
  
  def next_frame(frame)
    frame + 1
  end

  def is_first_throw_in_frame?
      @rolls.length.odd?
  end

  def first_throw_is_strike?
    is_first_throw_in_frame? && @rolls.last == 10
  end

  def is_spare_at?(frame)
    (open_score_for frame) == 10 && is_strike_at?(frame) == false
  end
  
  def is_strike_at?(frame)
    first_throw_for(frame) == 10
  end

  def first_throw_for(frame)
    score_at_throw(index_for(frame))
  end

  def second_throw_for(frame)
    score_at_throw(index_for(frame) + 1)
  end

  def index_for(frame)
    (frame - 1) * 2
  end

  def score_at_throw(index)
    @rolls.length > index ? @rolls[index] : 0
  end

  def open_score_for(frame)
    first_throw_for(frame) + second_throw_for(frame);
  end

  def spare_score_for(frame)
    open_score_for(frame) + first_throw_for(next_frame(frame))
  end

  def strike_score_for(frame)
    score = open_score_for(frame) + open_score_for(next_frame(frame))
    
    if is_strike_at? next_frame(frame)
      score += first_throw_for(next_frame(next_frame(frame)))
    end

    score
  end

end
