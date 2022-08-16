using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceDemo
{
    interface ISmartPhone
    {
         void OS();
         void Appstore();
        void ab();
    }
    interface Ifeature
    {
        void TouchID();
        void ab();
    }
    class Apple:ISmartPhone,Ifeature
    {
        public void OS()
        {
            Console.WriteLine("OS Method: iOS");
        }
        public void Appstore()
        {
            Console.WriteLine("Appstore method");
        }
        public void TouchID()
        {
            Console.WriteLine("Touch ID method");
        }
         void ISmartPhone.ab()
        {

        }
        void Ifeature.ab()
        {

        }
    }
    class Samsung : ISmartPhone
    {
        public void OS()
        {
            Console.WriteLine("OS Method:Android");
        }
        public void Appstore()
        {
            Console.WriteLine("Appstore method");
        }
        void ISmartPhone.ab()
        {

        }
    }
    //example of multiple inheritance not allowed in c#
    //abstract class SmartPhone
    //{
    //    public abstract void OS();
    //    public abstract void Appstore();
    //}
    //abstract class Features
    //{
    //    public abstract void TouchID();
    //}
    //class Apple:SmartPhone,Features
    //{
    //    public override void OS()
    //    {
    //        //im
    //    }
    //    public override void Appstore()
    //    {
    //        //
    //    }
    //}
    //class Samsung : SmartPhone
    //{
    //    public override void OS()
    //    {
    //        //im
    //    }
    //    public override void Appstore()
    //    {
    //        //
    //    }
    //}
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("/////////--Interface Demo--////////");
            Console.WriteLine("Apple smartphone");
            Apple apple = new Apple();
            apple.OS();
            apple.Appstore();
            apple.TouchID();

            Console.WriteLine("\n\n");
            Console.WriteLine("Samsung smartphone");
            Samsung samsung = new Samsung();
            samsung.OS();
            samsung.Appstore();
            Console.ReadKey();
        }
    }
}
