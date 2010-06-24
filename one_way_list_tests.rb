require 'test/unit'
require 'one_way_list'

class OneWayListTests < Test::Unit::TestCase
  
  def setup
    @list = OneWayList.new
  end
  
  def teardown
  end
  
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
  
  def test_searching_for_a_item_not_in_the_list_should_return_nil
    @list = OneWayList.new
    assert_nil(@list.find("fred"))
  end
  
  def test_after_adding_one_item_searching_should_find_it
    @list.add("fred")
    assert_equal("fred", @list.find("fred").value)
  end
  
  def test_after_adding_one_item_next_should_be_nil
    @list.add("fred")
    item = @list.find("fred")
    assert_nil(item.next)
  end
  
  def test_after_adding_one_item_searching_for_another_should_return_nil
    @list.add("fred")
    assert_nil(@list.find("wilma"))
  end
  
  def test_adding_multiple_items_is_cool
    @list.add("fred")
    @list.add("wilma")
    @list.add("betty")
    @list.add("barney")
    
    assert_equal(["fred", "wilma", "betty", "barney"], @list.values())
  end
  
  def test_we_can_delete_too
    @list.add("fred")
    @list.add("wilma")
    @list.add("betty")
    @list.add("barney")
    assert_equal(["fred", "wilma", "betty", "barney"], @list.values())
    @list.delete(@list.find("wilma"))
    assert_equal(["fred", "betty", "barney"], @list.values())
    @list.delete(@list.find("barney"))
    assert_equal(["fred", "betty"], @list.values())
    @list.delete(@list.find("fred"))
    assert_equal(["betty"], @list.values())
    @list.delete(@list.find("betty"))
    assert_equal([], @list.values())
  end
  
  def test_add_one_item_should_be_end
    @list.add("fred")
    item = @list.find("fred")
    assert_equal(@list.last, fred)
  end
  
  def test_WTH
    @list.add("fred")
    item = @list.find("fred")
    assert_nil(item.next)
    
    @list.add("wilma")
    item = @list.find("wilma")
    assert_nil(item.next)
    
    item = @list.find("fred")
    nextItem = item.next
    #assert_equal(nextItem.value, "wilma")
  end
  
end