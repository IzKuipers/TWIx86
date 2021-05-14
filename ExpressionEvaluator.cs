using System;
using System.Collections.Generic;

namespace TWIx86
{
	class ExpressionEvaluator
	{
		public enum TokenType
		{
			ParenOpen,
			Number,
			Add,
			Minus,
			Multiply,
			Divide
		}

		public class Token
		{
			public TokenType tokenType;
			public string value;

			public Token(TokenType tokenType, string value)
			{
				this.tokenType = tokenType;
				this.value = value;
			}

			public int GetPrecedence()
			{
				switch (tokenType)
				{
					case TokenType.Add:
					case TokenType.Minus:
						return 1;

					case TokenType.Multiply:
					case TokenType.Divide:
						return 2;

					default:
						return 0;
				}
			}
		}

		public List<Token> parse(string expr)
		{
			char character = ' ';
			Token token = null;
			Token popped = null;

			int offset = 0;
			string currNum = "";

			Stack<Token> opStack = new Stack<Token>();
			var outQueue = new List<Token>();

			while (offset < expr.Length)
			{
				character = expr[offset++];

				if (character == ' ')
				{
					continue;
				}

				while ((character == '.' || Char.IsDigit(character)) && offset <= expr.Length)
				{
					currNum += character;

					if (offset < expr.Length)
						character = expr[offset++];
					else break;
				}

				if (currNum != "")
				{
					outQueue.Add(new Token(TokenType.Number, currNum));
					if (offset < expr.Length) offset--;
					currNum = "";
					continue;
				}

				switch (character)
				{
					case '+':
						token = new Token(TokenType.Add, character.ToString());
						break;

					case '-':
						token = new Token(TokenType.Minus, character.ToString());
						break;

					case '*':
						token = new Token(TokenType.Multiply, character.ToString());
						break;

					case '/':
						token = new Token(TokenType.Divide, character.ToString());
						break;

					case '(':
						token = new Token(TokenType.ParenOpen, character.ToString());
						break;

					case ')':
						try
						{
							while ((popped = opStack.Pop()).tokenType != TokenType.ParenOpen)
							{
								outQueue.Add(popped);
							}
						}
						catch
						{
							throw new Exception("Mismatched parentheses");
						}
						continue;
				}

				if (token.tokenType == TokenType.ParenOpen)
				{
					opStack.Push(token);
					continue;
				}
				else
				{
					while (
						opStack.Count > 0 &&
						opStack.Peek().GetPrecedence() >= token.GetPrecedence() &&
						opStack.Peek().tokenType != TokenType.ParenOpen
					)
					{
						outQueue.Add(opStack.Pop());
					}
				}

				opStack.Push(token);
			}

			while (opStack.Count > 0)
			{
				outQueue.Add(opStack.Pop());
			}

			return outQueue;
		}

		public double evaluate(List<Token> queue)
		{
			Stack<double> numberStack = new Stack<double>();

			foreach (Token token in queue)
			{
				switch (token.tokenType)
				{
					case TokenType.Number:
						numberStack.Push(double.Parse(token.value));
						break;

					case TokenType.Add:
						numberStack.Push(numberStack.Pop() + numberStack.Pop());
						break;

					case TokenType.Minus:
						numberStack.Push(-numberStack.Pop() + numberStack.Pop());
						break;

					case TokenType.Multiply:
						numberStack.Push(numberStack.Pop() * numberStack.Pop());
						break;

					case TokenType.Divide:
						numberStack.Push((1 / numberStack.Pop()) * numberStack.Pop());
						break;
				}
			}

			return numberStack.Pop();
		}
	}
}
