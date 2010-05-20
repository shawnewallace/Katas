require 'rubygems'
gem 'rspec'
require 'fizz_buzz'

describe FizzBuzz do
  [
    [1,1],[2,2],[3,'fizz'],[4,4],[5,'buzz'],[6,'fizz'],[7,7],[8,8],
    [9,'fizz'],[10,'buzz'],[11,11],[12,'fizz'],[13,13],[14,14],[15,'fizzbuzz']
    ].each do |num, expected| 
    it "should be #{expected} when #{num}" do
      FizzBuzz.to(num).should == expected
    end
  end
  
  (1..100).to_a.each do |num|
    it "when #{num} should be 'fizz' when divisible by 3, 'buzz' when divisible by 5, 'fizzbuzz' when divisible by both and #{num} otherwise" do
      result = FizzBuzz.to(num)
      
      if num % 5 ==  0 and num % 3 == 0
        result.should == 'fizzbuzz'
      elsif num % 3 == 0
        result.should == 'fizz'
      elsif num % 5 == 0
        result.should == 'buzz'
      else
        result.should == num
      end
      
    end
  end
end