# RPNLib
Reverse Polish Notation (RPN) Library

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