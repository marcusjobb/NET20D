namespace TDDLektion1
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Calculator
    {
        public int Add(int a, int b) => a + b;

        public int Add(int[] numbers)
        {
            if (numbers == null) return 0;
            return numbers.Sum();
        }

        public int Divide(int a, int b)
        {
            if (b == 0)
            {
                return 0;
            }
            
            return a / b;
        }

    }
}
