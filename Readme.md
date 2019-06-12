# Merchant's Guide To Galaxy
      
The Merchant's Guide to Galaxy problem is as given below-      
A merchant buys and sells items in the galaxy. Buying and selling over the galaxy requires you to convert numbers and units. The numbers used for intergalactic transactions follows similar convention to the roman numerals. Roman numerals are based on seven symbols:    
      
I 1     
V 5      
X 10     
L 50      
C 100     
D 500      
m 1000     
Numbers are formed by combining symbols together and adding the values. For example, MMVI is 1000 + 1000 + 5 + 1 = 2006. Generally, symbols are placed in order of value, starting with the largest values. When smaller values precede larger values, the smaller values are subtracted from the larger values, and the result is added to the total. For example MCMXLIV = 1000 + (1000 - 100) + (50 - 10) + (5 - 1) = 1944.    
      
The symbols "I", "X", "C", and "M" can be repeated three times in succession, but no more. (They may appear four times if the third and fourth are separated by a smaller value, such as XXXIX.) "D", "L", and "V" can never be repeated. "I" can be subtracted from "V" and "X" only. "X" can be subtracted from "L" and "C" only. "C" can be subtracted from "D" and "M" only. "V", "L", and "D" can never be subtracted. Only one small-value symbol may be subtracted from any large-value symbol. A number written in [16]Arabic numerals can be broken into digits. For example, 1903 is composed of 1, 9, 0, and 3. To write the Roman numeral, each of the non-zero digits should be treated separately. Inthe above example, 1,000 = M, 900 = CM, and 3 = III. Therefore, 1903 = MCMIII. Input to your program consists of lines of text detailing your notes on the conversion between intergalactic units and roman numerals. You are expected to handle invalid queries appropriately.     
        
Test input      
glob is I     
prok is V     
pish is X     
tegj is L     
glob glob Silver is 34 Credits      
glob prok Gold is 57800 Credits      
pish pish Iron is 3910 Credits         
how much is pish tegj glob glob ?      
how many Credits is glob prok Silver ?      
how many Credits is glob prok Gold ?      
how many Credits is glob prok Iron ?       
how much wood could a woodchuck chuck if a woodchuck could chuck wood ?     
      
Test Output     
pish tegj glob glob is 42     
glob prok Silver is 68 Credits     
glob prok Gold is 57800 Credits     
glob prok Iron is 782 Credits      
I have no idea what you are talking about     
      
The solution provided here is a generic, maintainable, extensible and testable solution to the Merchant's Guide to the Galaxy  problem without using any Programming Language Construction Toolkit like [Jigsaw](https://code.google.com/archive/p/jigsaw-library/), [Antlr](https://en.wikipedia.org/wiki/ANTLR) or [Irony](https://www.codeproject.com/Articles/22650/Irony-NET-Compiler-Construction-Kit).          
Another good solution to the same problem using Compiler Construction terminologies can be found [here](http://awizkid.tumblr.com/post/100081789976/merchants-guide-to-galaxy).   

References -
Some good references to solve this kind of Compiler Construction type problems or to build your own cool Programming Construction toolkit are -
1) [Implementing Programming Languages using C# 4.0](https://www.codeproject.com/articles/272494/implementing-programming-languages-using-csharp)      
2) [Build your own .NET Language and Compiler](https://www.apress.com/in/book/9781590591345)            
3) [Domain Specific Language in .NET](https://udooz.pressbooks.com/)        
4) [Language Implementation Patterns](https://pragprog.com/book/tpdsl/language-implementation-patterns)           
5) [Domain Specific Languages](https://www.martinfowler.com/books/dsl.html)       
6) [A Catalog of Patterns for Program Generation](http://www.voelter.de/data/pub/ProgramGeneration.pdf)         
7) [Programming Language Pragmatics](https://www.cs.rochester.edu/~scott/pragmatics/)(a bit academic)                               
8) [Awesome Roslyn](https://github.com/ironcev/awesome-roslyn) and [Roslyn Samples and Walkthroughs](https://github.com/dotnet/roslyn/wiki/Samples-and-Walkthroughs)                  
9) [Masterminds of Programming](http://shop.oreilly.com/product/9780596515171.do)          
