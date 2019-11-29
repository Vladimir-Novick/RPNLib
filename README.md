# RPNLib
Reverse Polish Notation (RPN) Calculator Library

Reverse Polish notation (RPN) is a method for representing arifmetical expressions in which the operator symbol is placed after the arguments being operated on.
Polish notation, in which the operator comes before the operands, was invented in the 1920s by the Polish mathematician Jan Lucasiewicz. 

Using:

				String sourceString = "((15 / (7 - (1 + 1))) * 3) - (2 + (1 + 1)) ";
				var compiler = new RPNExpression(sourceString);
				var rezult = compiler.Calculate().ToString();


With arguments: 

				var compiler = new RPNExpression("4/12*100+(A*B)");
				var RPNString = compiler.Prepare();
				List<RPNArguments> arguments = new List<RPNArguments>();
				arguments.Add(new RPNArguments("A", 2));
				arguments.Add(new RPNArguments("B", 7));
				var rezult = compiler.Calculate(arguments).ToString();

With functions:

				 String sourceString = "ACOS(-(0.5+0.5)) -20 +5";
				 var compiler = new RPNExpression(sourceString);
				 var rezult = compiler.Calculate().ToString();


Mathematical notation:

| Symbol	|  Symbol Name	|        definition            |       Example    |
| --------- | ------------- |----------------------------- |----------------- |
|			|				|		   |
|( )| parentheses |	calculate expression inside first |	2 × (3+5) = 16|
|+	|plus sign	| addition	|   1 + 1 = 2   |
|−	|minus sign	|subtraction|	2 − 1 = 1   |
|*	|asterisk	|multiplication|	2 * 3 = 6|
|/	|division slash|	division|	6 / 2 = 3|
|^	|Exponentiation sign|	Exponentiation Operator |	3 ^ 2 = 9 |


Functions:

| Functions  | Functions |
| ------------- | ------------- |
|	ASin(argument)	|	Cosh(argument)
|	Cos(argument)   |   ACos(argument)          
|	Log10(argument) |   Log(argument)
|	Tan(argument)	|	ATan(argument)
|	Sin(argument)   |   Sinh(argument)
|	Tanh(argument)  |   Sqrt(argument)
|	PI()      		|	Random()   
|	Abs(argument)	|
|					|
|	Date()			|	 Now()              
|	Time()       	|	 Year()          
|	Day()       	|	 Month()  	

where 	"argument" - constant or mathematical expression		
                                
                                
            
            
            
            
            
            
            
            
            
            
            
            
            
            