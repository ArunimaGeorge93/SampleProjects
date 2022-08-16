using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticUsageDemo
{
    class Program
    {
        Program()
        {

        }
        public static int firstNumber = 10;
        private static int secondNumber = 20;

        public static string fName = "a";
        public string mName = "b";
        public static string lName = "c";
        static void Main(string[] args)
        {
            Program obj1 = new Program();
            Console.WriteLine("Sum of two numbers is {0}", obj1.AddNumbers(Program.firstNumber, Program.secondNumber));

            Program obj2 = new Program();
            obj2.PrintStaticVariable();
            Program obj3 = new Program();
            obj3.PrintStaticVariable();

            Console.WriteLine("Print full name : {0}", Program.PrintNames(Program.fName, obj1.mName, Program.lName));

        }
        public int AddNumbers(int fNumber, int secondNumber)
        {
            fNumber = fNumber + 10;
            return fNumber + secondNumber;
        }
        public void PrintStaticVariable()
        {
            firstNumber = firstNumber + 10;
            Console.WriteLine("firstnumber is {0}", firstNumber);
        }
        public static string PrintNames(string finame,string secname,string ltname)
        {
            Program pgm = new Program();
            return finame + pgm.mName + ltname;
        }
    }
}
