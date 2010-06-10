require 'fibonacci'

(0..100).each do |n|
  print "Fib: #{n}\n"
  puts Fibonacci.phi
  puts Fibonacci.of(n)
  puts Fibonacci.ofIterative(n)
end