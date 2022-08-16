using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Samplecode
{
   public class Program
    {
        static void Main(string[] args)
        {
            Myclass obj = new Myclass();
            obj.LongRunning(Callback);
        }
        static void Callback(int i)
        {
            Console.WriteLine(i);
        }
    }
    public class Myclass
    {
        public delegate void CallBack(int i);
        public void LongRunning(CallBack obj)
        {
            for (int i = 0; i < 1000; i++)
            {
                //does something
                obj(i);
            }
        }
    }
}
