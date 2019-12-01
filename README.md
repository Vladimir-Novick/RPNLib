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


Mathematical notations:

| Symbol	|  Symbol Name	|        Definition            |       Example    |
| --------- | ------------- |----------------------------- |----------------- |
|( )| parentheses |	calculate expression inside first |	2 × (3+5) = 16|
|+	|plus sign	| addition	|   1 + 1 = 2   |
|−	|minus sign	|subtraction|	2 − 1 = 1   |
|*	|asterisk	|multiplication|	2 * 3 = 6|
|/	|division slash|	division|	6 / 2 = 3|
|÷	|division sign / obelus|	division|	6 ÷ 2 = 3|
|^	|Exponentiation sign|	exponent |	2 ^ 3 = 8 |
|%	|percent	|1% = 1/100|	10% × 30 = 3|



Logical notations:

| Symbol	|  Symbol Name	|        Definition            |       Example    |
| --------- | ------------- |----------------------------- |----------------- |
|=	|Equalent|	Equalent|	5 = 5 |
|==	|Equalent|	Equalent|	5 == 5 |
|>	|strict inequality|	greater than|	5 > 4 5 is greater than 4|
|<	|strict inequality|	less than	|4 < 5 4 is less than 5|
|≥	|inequality	|greater than or equal to	|5 ≥ 4, x ≥ y means x is greater than or equal to y|
|>=	|inequality	|greater than or equal to	|5 >= 4, x >= y means x is greater than or equal to y|
|≤	|inequality	|less than or equal to	|4 ≤ 5, x ≤ y means x is less than or equal to y|
|<=	|inequality	|less than or equal to	|4 <= 5, x <= y means x is less than or equal to y|
| \|\| | Or|	5 = x\|\| 4 = y |
| && |And |	5 = x && 4 = x|
| ! |Not | !(5 = x) |



Functions:

| Functions  |         Definition            |
| -----------|------------------------------ |
|If(x)|x - logical expression . if true next expression is executed| 
|ACos(x)| Arccosine function.| 
|ASin(x)| returns the Inverse Sin  |
|ATan(x)|Arctan(x), tan-1(x), inverse tangent function. |
|Cos(x)| Cosine function. |  
|Cosh(x)|Inverse hyperbolic cosine |
|Log(x)| Natural logarithm | 
|Log10(x)| Logarithm 10 |
|Sin(x)|  sin(x), sine function.  |
|Sinh(x)|Inverse hyperbolic sine | 
|Sqrt(x)|Square Root | 
|Tan(x)|tangent function. | 
|Tanh(x)|Hyperbolic tangent | 
|PI()| Number Pi Mathematical Constant |
|Now()| Current Date and Time |
|Date()|Currentn Date |
|Time()|Current Time  |
|Day()| Current Day   |
|Month()| Current Month |
|Year()| Current Year |
|Abs(x)|            | 
|Round(x)|            |
|Random()|            | 

where 	"x" - constant or mathematical expression		
                                
                                
            
            
            
            
            
            
            
            
            
            
            
            
            
            