module NumToRoman
  RomanNumerals = { 1=>'I', 5=>'V', 10=>'X',
    50=>'L', 100=>'C', 500=>'D', 1000=>'M' }
    
    Subtractors = [ [1000, 100], [500, 100], [100, 10],
      [50, 10], [10, 1], [5, 1], [1, 0] ]
  
  def self.to_roman(num)
    return nil if num > 3999
    
    return RomanNumerals[num] if RomanNumerals.has_key?(num)
    
    Subtractors.each do |cutoff, subtractor|
      
      return to_roman(cutoff) + to_roman(num - cutoff)          if num > cutoff
      return to_roman(subtractor) + to_roman(num + subtractor)  if num >= cutoff - subtractor and num < cutoff
    
    end
  end
end