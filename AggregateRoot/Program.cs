using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AggregateRoot
{
    class Program
    {
       
        static void Main(string[] args)
        {
            
            Customer cust = new Customer();
            cust.CustomerName = "AG";
            cust.DateofBirth = Convert.ToDateTime("01/01/2000");

            Address Address1 = new Address();
            Address1.Address1 = "Kerala";
            Address1.Type = "Home";

            cust.Addresses = new List<Address>();
            cust.Addresses.Add(Address1);
            //cust.Addresses.Add(new Address() { Address1="Kerala",Type="Home"})

            Console.WriteLine(cust.Addresses[0].Address1+"------------>"+cust.Addresses[0].Type);

            //Address addrs2 = new Address();
            //addrs2.Address1 = "TN";
            //addrs2.Type = "Home";
            //cust.Addresses.Add(addrs2);
        }
    }

    class Customer
    {
        public string CustomerName { get; set; }
        public DateTime DateofBirth { get; set; }
        public List<Address> Addresses { get; set; }
    }
    class Address
    {
        public string Address1 { get; set; }
        public string Type { get; set; }
    }
}
