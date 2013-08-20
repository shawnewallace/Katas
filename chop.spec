require 'rubygems'
gem 'rspec'
require 'chop'

#http://codekata.pragprog.com/2007/01/kata_two_karate.html

describe Chop do
  [
    [-1, 3, []],
    [-1, 3, [1]],
    [0, 1, [1]],
    [0, 1, [1, 3, 5]],
    [1, 3, [1, 3, 5]],
    [2, 5, [1, 3, 5]],
    [-1, 0, [1, 3, 5]],
    [-1, 2, [1, 3, 5]],
    [-1, 4, [1, 3, 5]],
    [-1, 6, [1, 3, 5]],
    [0, 1, [1, 3, 5, 7]],
    [1, 3, [1, 3, 5, 7]],
    [2, 5, [1, 3, 5, 7]],
    [3, 7, [1, 3, 5, 7]],
    [-1, 0, [1, 3, 5, 7]],
    [-1, 2, [1, 3, 5, 7]],
    [-1, 4, [1, 3, 5, 7]],
    [-1, 6, [1, 3, 5, 7]],
    [-1, 8, [1, 3, 5, 7]]
    ].each do |expected, toFind, array|
      it "should be #{expected} when looking for #{toFind} in [#{array}]" do
        Chop.doBinarySearch(toFind, array).should == expected
      end
    end
end
