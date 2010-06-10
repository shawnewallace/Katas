require 'test/unit'
require 'one_way_list'

class OneWayListTests < Test::Unit::TestCase
  
  def test_smoke
    
    list = OneWayList.new
    
    assert_nil(list.find("fred"))
    list.add("fred")
    assert_equal("fred", list.find("fred").value)
    assert_nil(list.find("wilma"))
    #list.add("wilma")
    #assert_equal("fred",  list.find("fred").value())
    #assert_equal("wilma", list.find("wilma").value())
    #assert_equal(["fred", "wilma"], list.values())
    
  end
end