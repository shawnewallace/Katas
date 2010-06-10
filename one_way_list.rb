class OneWayList
  
  def initialize()
    @item = nil
  end
  
  def find(toFind)
    @item
  end
  
  def add(toAdd)
    @item = OneWayListItem.new if @item == nil
    
    @item.value = toAdd
  end
end

class OneWayListItem
  attr_accessor :value
end