class OneWayList
  
  #@items = Array.new
  
  def initialize()
    @items = Array.new
  end
  
  def find(toFind)
    
    @items.each do |val|
      return val if val.value == toFind
    end
    
    nil
  end
  
  def add(toAdd)
    #@item = OneWayListItem.new if @item == nil
    newItem = OneWayListItem.new
    newItem.value = toAdd
    @items.push(newItem)  
  end
  
  def delete(itemToDelete)
    @items.delete(itemToDelete)
  end
  
  def values()
    array = Array.new
    @items.each do |val|
      array.push(val.value)
    end
    
    array
  end
end

class OneWayListItem
  attr_accessor :value
end