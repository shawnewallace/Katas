require 'test/unit'
require 'one_way_list'

class OneWayListTests < Test::Unit::TestCase
  
  def test_smoke
    
    list = OneWayList.new
    
    assert_nil(list.find("fred"))
    list.add("fred")
    assert_equal("fred", list.find("fred").value)
    assert_nil(list.find("wilma"))
    list.add("wilma")
    assert_equal("fred",  list.find("fred").value())
    assert_equal("wilma", list.find("wilma").value())
    assert_equal(["fred", "wilma"], list.values())
    
    list = OneWayList.new
    list.add("fred")
    list.add("wilma")
    list.add("betty")
    list.add("barney")
    assert_equal(["fred", "wilma", "betty", "barney"], list.values())
    list.delete(list.find("wilma"))
    assert_equal(["fred", "betty", "barney"], list.values())
    list.delete(list.find("barney"))
    assert_equal(["fred", "betty"], list.values())
    list.delete(list.find("fred"))
    assert_equal(["betty"], list.values())
    list.delete(list.find("betty"))
    assert_equal([], list.values())
  end
end