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
      
The solution provided here is a generic, maintainable, extensible and testable solution to the Merchant's Guide to Galaxy  problem without using any Programming Language Construction Toolkit like [Jigsaw](https://code.google.com/archive/p/jigsaw-library/), [Antlr](https://en.wikipedia.org/wiki/ANTLR) or [Irony](https://www.codeproject.com/Articles/22650/Irony-NET-Compiler-Construction-Kit).


Sometimes you might need to create a language for your domain(something similar to compiler or interpreter construction) and such languages are called Domain Specific Languages.Some good references to solve any kind of Compiler Construction type problems or to build your own cool Programming Construction toolkit are -          
1) [A Guide to Parsing: Algorithms and Terminology](https://tomassetti.me/guide-parsing-algorithms-terminology/)       
2) [Automata Theory](https://en.m.wikipedia.org/wiki/Automata_theory)        
3) [State Machines and Automata](https://www.packtpub.com/en-in/product/state-machines-and-automata-building-a-regexp-machine-9781801076944)      
4) [Implementing Programming Languages using C# 4.0](https://www.codeproject.com/articles/272494/implementing-programming-languages-using-csharp)                            
5) [Implementing a Custom Language Succinctly](https://www.syncfusion.com/ebooks/implementing-a-custom-language)       
   N.B. -> A sequel to the above text is [Writing Native Mobile Apps in a Functional Language Succinctly] 
(https://www.syncfusion.com/ebooks/writing_native_mobile_apps_in_a_functional_language_succinctly)                     
6) [Language Implementation Patterns](https://pragprog.com/titles/tpdsl/language-implementation-patterns/)                      
7) [Domain Specific Languages](https://www.martinfowler.com/books/dsl.html)
8) [Building your own Programming Language](https://www.packtpub.com/en-in/product/build-your-own-programming-language-9781804618028)
9) [Role of VM in Programming Languages](https://www.linkedin.com/advice/0/what-role-virtual-machine-programming-languages-vexfe?utm_source=share&utm_medium=member_ios&utm_campaign=share_via#:~:text=A%20Virtual%20Machine%20(VM)%20plays,deployment%20easier%20and%20more%20efficient.), [Build your own VM](https://www.codeproject.com/Articles/43176/How-to-create-your-own-virtual-machine) & [Udemy's Building a VM for a Programming Language course](https://www.udemy.com/course/virtual-machine/)        
10) [Roslyn Succintly](https://www.syncfusion.com/ebooks/roslyn), [Awesome Roslyn](https://github.com/ironcev/awesome-roslyn) and [Roslyn Samples and Walkthroughs](https://github.com/dotnet/roslyn/wiki/Samples-and-Walkthroughs)                  
11) [Masterminds of Programming](http://shop.oreilly.com/product/9780596515171.do)             
12) Some other good (.NETish) resources are like [Easy way to create a C# lambda expression from a string (with Roslyn)](https://www.strathweb.com/2018/01/easy-way-to-create-a-c-lambda-expression-from-a-string-with-roslyn/), [Evaluating mathematical expressions with custom script functions](https://stackoverflow.com/questions/43817154/evaluating-mathematical-expressions-with-custom-script-functions), [Dynamic compilation as a very fast mathematic parser in .NET](http://www.naun.org/main/NAUN/mcs/2015/a082002-224.pdf) and [Building a Dynamic Business Rules Engine](https://www.growthaccelerationpartners.com/blog/dynamic-business-rules-engine/).


Disclaimer - I have not read/gone-through e2e of all the resources mentioned above(especially the paid ones). For the paid ones, mainly checked the ToC, reviews & other articles where they have been referred as recommended resources.Also some resources links might not be working due to various reasons, although they were working at the time of initial drafting.
