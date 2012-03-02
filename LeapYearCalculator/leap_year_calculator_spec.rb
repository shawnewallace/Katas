#A year will be a leap year if
#it is divisible by 4 but not by 100.
#If a year is divisible by 4 and by 100,
#it is not a leap year unless it is also divisible by 400.



class LeapYearCalculator
  def IsLeapYear?(year)
    return false if  (year % 4)  != 0
    return true if (year % 100) != 0
    return true if  (year % 400) == 0
    return false
  end
end


describe LeapYearCalculator do

  describe "IsLeapYear?" do

    [
      [1600, true],
      [1700, false],
      [2011, false],
      [2012, true],
      [2013, false],
      [2016, true],
      [2100, false],
      [2800, true],
      [2804, true]
    ].each do |year, expected|
      it "is #{expected} for #{year}" do
        calc = LeapYearCalculator.new
        calc.IsLeapYear?(year).should == expected
      end
    end
  end
end

