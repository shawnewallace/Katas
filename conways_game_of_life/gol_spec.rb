require 'rspec'

class Cell
  attr_accessor :world, :x, :y
  
  def initialize(world, x=0, y=0)
    @world = world
    @x = x
    @y = y
    world.cells << self
  end

  def die!
    world.cells -= [self]
  end

  def dead?
    !world.cells.include?(self)
  end

  def alive?
    world.cells.include?(self)
  end

  def neighbors
    @neighbors = []
    world.cells.each do |cell|
      #north(0, 1)
      if (self.x == cell.x && self.y == cell.y + 1)
        @neighbors << cell
      end
      #northeast(1, 1)
      #east(1, 0)
      #southeast(1, -1)
      #south(0, -1)
      #southwest(-1, -1)
      #west(-1, 0)
      #northwest(-1, 1)
    end

    @neighbors
  end

  def spawn_at(x, y)
    Cell.new(world, x, y)
  end
end

class World
  attr_accessor :cells
  def initialize
    @cells = []
  end

  def tick!
    cells.each do |cell|
      if cell.neighbors.count < 2
        cell.die!
      end
    end
  end
end

describe 'game of life' do
  let(:world) { World.new }
  context 'cell utility methods' do
    subject { Cell.new(world) }
    it "spawn relative to" do
      cell = subject.spawn_at(3, 5)
      cell.is_a?(Cell).should be_true
      cell.x.should == 3
      cell.y.should == 5
      cell.world.should == subject.world
    end

    it "detects a neighbor to the north" do
      cell = subject.spawn_at(0, 1)
      subject.neighbors.count.should == 1
    end

    it "detects a neighbor to the northeast" do
      cell = subject.spawn_at(1, 1)
     subject.neighbors.count == 1
    end

    it "detects a neighbor to the west" do
      cell = subject.spawn_at(-1, 0)
      subject.neighbors.count.should == 1
    end

    it "detects a neighbor to the east" do
      cell = subject.spawn_at(1, 0)
      subject.neighbors.count.should == 1
    end

    it "detects a neighbor to the southeast" do
      cell = subject.spawn_at(1, -1)
      subject.neighbors.count.should == 1
    end

    it "detects a neighbor to the northwest" do
      cell = subject.spawn_at(-1, 1)
      subject.neighbors.count.should == 1
    end

     it "detects a neighbor to the southwest" do
      cell = subject.spawn_at(-1, -1)
      subject.neighbors.count.should == 1
    end

     it "detects a neighbor to the south" do
       cell = subject.spawn_at(0, -1)
       subject.neighbors.count.should == 1
     end


    it "dies" do
      subject.die!
      subject.world.cells.should_not include(subject)
    end
  end

  it "Rule #1:  Any live cell with fewer than two live neighbors dies, as if by underpopulation." do
    cell = Cell.new(world)
    new_cell = cell.spawn_at(2, 0)
    world.tick!
    cell.should be_dead
  end

  it "Rule #2:  Any live cell with two or three neighbors lives on to the next generation." do
    cell = Cell.new(world)
    new_cell = cell.spawn_at(1, 0)
    other_new_cell = cell.spawn_at(-1, 0)
    world.tick!
    cell.should be_alive
  end

  it "Rule #3:  Any live cell with more than three live neighbours dies, as if by overcrowding." do
    cell = Cell.new(world)
    cell.spawn_at(-1, -1) #northwest
    cell.spawn_at(0, -1) #north
    cell.spawn_at(1, 1) #northeast
    cell.spawn_at(1, 0) #east
    world.tick!
    cell.should be_dead
  end

  it "Rule #4:  Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction." do

  end
end
