require 'rubygems'
gem 'rspec'
require 'num_to_roman'

describe NumToRoman do
    [
      ['I',      1], ['II',     2], ['III',     3], ['IV',      4],
      ['V',      5], ['VI',     6], ['VII',     7], ['VIII',    8],
      ['IX',     9], ['X',     10], ['XI',     11], ['XII',    12],
      ['XIII',  13], ['XIV',   14], ['XV',     15], ['XVI',    16],
      ['XVII',  17], ['XVIII', 18], ['XIX',    19], ['XX',     20],
      ['XXI',   21], ['XXIII', 23], ['XXIV',   24], ['XXV',    25],
      ['XXIX',  29], ['XXX',   30], ['XXXIV',  34], ['XXXVI',  36],
      ['XXXIX', 39], ['XL',    40], ['L',      50], ['LIV',    54],
      ['LVIII', 58], ['LIX',   59], ['LXXVI',  76], ['LXXXIX', 89],
      ['XC',    90], ['XCIV',  94], ['XCVIII', 98], ['XCIX',   99],
      ['C',    100], ['XLIV',  44], ['MMMCMXCIX', 3999], ['MCMLXXI', 1971]
    ].each do |romanNumeral, num|
    it "should convert #{num} to #{romanNumeral}" do
      NumToRoman.to_roman(num).should == romanNumeral
    end
  end
    
    [4000,4567,9287,10000].each do |num|
    it "should NOT convert #{num}" do
      NumToRoman.to_roman(num).should == nil
    end
  end
end
