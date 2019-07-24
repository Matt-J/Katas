The challenge is fairly simple: given a file containing one word per line, print out all the combinations of words that are anagrams; 
each line in the output contains all the words from the input that are anagrams of each other. 

For example, your program might include in its output:

1  kinship pinkish
2  enlist inlets listen silent
3  boaster boaters borates
4  fresher refresh
5  sinks skins
6  knits stink
7  rots sort

If you run this on the word list in the solution you should find 20683 sets of anagrams (a total of 48162 words), including all-time favorites such as

1 crepitus cuprites pictures piecrust
2 paste pates peats septa spate tapes tepas
3 punctilio unpolitic
4 sunders undress

For added programming pleasure, find the longest words that are anagrams, and find the set of anagrams containing the most words (so “parsley players replays sparely” would not win, having only four words in the set).

Kata Objectives
Apart from having some fun with words, this kata should make you think somewhat about algorithms. 
The simplest algorithms to find all the anagram combinations may take inordinate amounts of time to do the job. 
Working though alternatives should help bring the time down by orders of magnitude. 
To give you a possible point of comparison, I hacked a solution together in 25 lines of Ruby. It runs on this wordlist in 1.8s on a 1.7GHz i7. 
It’s also an interesting exercise in testing: can you write unit tests to verify that your code is working correctly before setting it to work on the full dictionary.