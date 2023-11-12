namespace Calc
{
    class CalcExpression
    {
        private string expression;

        public CalcExpression(string expression)
        {
            this.expression = expression;
        }

        public double Calculate()
        {
            

            string[] str = expression.Split('(', ')', ',');

            if (str.Length < 2)
            {
                throw new ArgumentException("Invalid expression format.");
            }

            string functionName = str[0].ToLower();
            double arg1 = double.Parse(str[1]);

            double result = 0;

            switch (functionName)
            {
                case "sqrt":
                    result = Math.Sqrt(arg1);
                    break;
                case "pow":
                    if (str.Length < 3)
                    {
                        throw new ArgumentException("Invalid number of arguments for pow function.");
                    }
                    double arg2 = double.Parse(str[2]);
                    result = Math.Pow(arg1, arg2);
                    break;
                case "sin":
                    result = Math.Sin(arg1);
                    break;
                case "cos":
                    result = Math.Cos(arg1);
                    break;

                case "tan":
                    result = Math.Tan(arg1);
                    break;
                case "Atan":
                    result = Math.Atan(arg1);
                    break;

                default:
                    throw new ArgumentException($"Unknown function: {functionName}");
                    break;
            }

            return result;

            
        }
        
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter expression: ");
            string expression = Console.ReadLine();

            CalcExpression calc = new CalcExpression(expression);

            try
            {
                double result = calc.Calculate();
                Console.WriteLine($"Result: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}