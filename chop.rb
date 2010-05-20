module Chop
  def self.doBinarySearch(toFind, findIn)
    binary_search(findIn, 0, findIn.length - 1, toFind)
  end
  
  def self.binary_search(list, lower, upper, target)
    return -1 if lower > upper
    
    mid = (lower + upper) / 2
    
    if (list[mid] == target)
      mid
    elsif (target < list[mid])
     binary_search(list, lower, mid - 1, target)
   else
     binary_search(list, mid + 1, upper, target)
   end
  end
  
end