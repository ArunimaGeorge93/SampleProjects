using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassDemo
{
    abstract class iPhone {
        //no abstract method
        public void call()
        {
            Console.WriteLine("call method:this method provides calling features");
        }
    
    } //definition of abstract class
    class Program:iPhone
    {
        static void Main(string[] args)
        {
            //Program pgmobj = new Program();
            //pgmobj.call();
            Galaxy obj = new Galaxy();
            obj.call();
            obj.Model();
            obj.LaunchDate();
            Console.ReadKey();
        }
    }
}
