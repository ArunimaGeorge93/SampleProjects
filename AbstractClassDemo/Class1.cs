using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractClassDemo
{
    abstract class Samsung
    {
        //no abstract method
        public void call()
        {
            Console.WriteLine("call method SAMSUNG:this method provides calling features");
        }
        public abstract void Model(); //abstract method

    } //definition of abstract class
    class Galaxy:Samsung
    {
        public override void Model() //sbstract method implementation
        {
            Console.WriteLine("Model: Model of this samsung phone is Galaxy");
        }
        public void LaunchDate() //derived class local method
        {
            Console.WriteLine("Launch Date: xxxx");
        }
    }
    class Class1
    {
        
    }
}
