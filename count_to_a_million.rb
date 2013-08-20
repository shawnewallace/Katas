

(1..1000).to_a.each do |num|
  puts num if num % 7 == 0
end


# encoding: utf-8
puts "Greek pi: \u03c0" # => "Greek pi: "
puts "Greek pi: \u{3c0}" # => "Greek pi: "
puts "Greek \u{70 69 3a 20 3c0}" # => "Greek pi: "

