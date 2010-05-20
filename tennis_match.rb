class TennisMatch
  def TranslateScore(score)
    case
      when score == 0; 'love'
      when score == 1; 'fifteen'
      when score == 2; 'thirty'
      else 'forty'
    end
  end
  
  def ScoreOne
    return TranslateScore(@ScoreOne)
  end
  
  def ScoreTwo
    return TranslateScore(@ScoreTwo)
  end
  
  def initialize()
    @ScoreOne = 0
    @ScoreTwo = 0
  end
  
  def Score()
    case
      when (@ScoreOne >= 4 and @ScoreOne - 2 >= @ScoreTwo)
        return "player one wins"
      when (@ScoreTwo >= 4 and @ScoreTwo - 2 >= @ScoreOne)
        return "player two wins"
      when (@ScoreOne >= 3 and @ScoreTwo >= 3 and @ScoreOne == @ScoreTwo)
        return "deuce"
      when (@ScoreOne >= 3 and @ScoreTwo >= 3 and @ScoreOne > @ScoreTwo)
        return "advantage player one"
      when (@ScoreOne >= 3 and @ScoreTwo >=3 and @ScoreOne < @ScoreTwo)
        return "advantage player two"
      else
        "#{ScoreOne()}-#{ScoreTwo()}"
    end
  end
  
  def PlayerOneScores()
    @ScoreOne = @ScoreOne + 1
  end
  
  def PlayerTwoScores()
    @ScoreTwo = @ScoreTwo + 1
  end
end